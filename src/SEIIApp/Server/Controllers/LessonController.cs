using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using SEIIApp.Server.Domain;
using SEIIApp.Server.Services;
using SEIIApp.Shared.DomainTdo;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SEIIApp.Server.Data;
using SEIIApp.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace SEIIApp.Server.Controllers
{


    [ApiController]
    [Route("api/lessondefinitions")]
    public class LessonDefinitionController : ControllerBase
    {

        private LessonDefinitionService LessonDefinitionService { get; set; }
        private IMapper Mapper { get; set; }

        public LessonDefinitionController(LessonDefinitionService lessonDefinitionService, IMapper mapper)
        {
            this.LessonDefinitionService = lessonDefinitionService;
            this.Mapper = mapper;
        }

        /// <summary>
        /// Return the lesson with the given id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Shared.DomainTdo.LessonDefinitionDto> GetLesson([FromRoute] int id)
        {
            var lesson = LessonDefinitionService.GetLessonWithid(id);
            if (lesson == null) return StatusCode(StatusCodes.Status404NotFound);

            var mappedLesson = Mapper.Map<LessonDefinitionDto>(lesson);
            return Ok(mappedLesson);
        }

        /// <summary>
        /// Returns all lessons.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<LessonDefinitionDto[]> GetAllLessons()
        {
            var lessons = LessonDefinitionService.GetAllLessons();
            var mappedLessons = Mapper.Map<LessonDefinitionDto[]>(lessons);
            return Ok(mappedLessons);
        }

        /// <summary>
        /// Adds or updates a lesson definition.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public ActionResult<LessonDefinitionDto> AddOrUpdateLessonProfil([FromBody] LessonDefinitionDto model)
        {
            if (ModelState.IsValid) 
            {
                //Das Modell ist dann valide, wenn es die per Annotation definierten
                //Eigenschaften erfüllt, ansonsten werden wir einen Fehler zurückliefern.

                //Wir "mappen" das gelieferte Modell zu unserer lokalen Domänen-Repräsentation
                var mappedModel = Mapper.Map<LessonDefinition>(model);

               

                if (model.id == 0)
                { //add
                  try { 
                        mappedModel = LessonDefinitionService.AddLesson(mappedModel);
                    }catch
                    { 
                    return Conflict(ModelState);
                    }
                    }
                else
                { //update
                    mappedModel = LessonDefinitionService.UpdateLesson(mappedModel);
                }

                //Wir liefern das geänderte Objekt auch wieder zurück
                
                model = Mapper.Map<LessonDefinitionDto>(mappedModel);
                return Ok(model);
            }
            return BadRequest(ModelState);
        }

        /// <summary>
        /// Removes a lesson definition.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult DeleteLesson([FromRoute] int id)
        {
            var lesson = LessonDefinitionService.GetLessonWithid(id);
            if (lesson == null) return StatusCode(StatusCodes.Status404NotFound);

            LessonDefinitionService.RemoveLesson(lesson);
            return Ok();
        }
    }
}
