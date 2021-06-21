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
    [Route("api/lessonprofildefinitions")]
    public class LessonProfilDefinitionController : ControllerBase
    {

        private LessonProfilDefinitionService LessonProfilDefinitionService { get; set; }
        private IMapper Mapper { get; set; }

        public LessonProfilDefinitionController(LessonProfilDefinitionService lessonProfilDefinitionService, IMapper mapper)
        {
            this.LessonProfilDefinitionService = lessonProfilDefinitionService;
            this.Mapper = mapper;
        }

        /// <summary>
        /// Return the lessonprofil with the given id.
        /// </summary>
        /// <param name="lessonProfilId"></param>
        /// <returns></returns>
        [HttpGet("{lessonProfilId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Shared.DomainTdo.LessonProfilDefinitionDto> GetLessonProfil([FromRoute] int lessonProfilId)
        {
            var lessonProfil = LessonProfilDefinitionService.GetLessonProfilWithid(lessonProfilId);
            if (lessonProfil == null) return StatusCode(StatusCodes.Status404NotFound);

            var mappedLessonProfil = Mapper.Map<LessonProfilDefinitionDto>(lessonProfil);
            return Ok(mappedLessonProfil);
        }

        /// <summary>
        /// Returns all lessonprofils for a lessonNumber.
        /// </summary>
        /// <returns></returns>
        [HttpGet("AllHelpingHandForLesson/{lessonNumber}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<LessonProfilDefinitionDto[]> GetAllLessonsProfilForLessonNumber([FromRoute] int lessonNumber)
        {
           
            var lessonsProfil = LessonProfilDefinitionService.GetAllLessonsProfilForLessonNumber(lessonNumber);
            if (lessonsProfil == null) return StatusCode(StatusCodes.Status404NotFound);
            var mappedLessonsProfil = Mapper.Map<LessonProfilDefinitionDto[]>(lessonsProfil);
            return Ok(mappedLessonsProfil);
        }

        /// <summary>
        /// Returns all lessonprofils.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<LessonProfilDefinitionDto[]> GetAllLessonsProfil()
        {
            var lessonsProfil = LessonProfilDefinitionService.GetAllLessonsProfil();
            var mappedLessonsProfil = Mapper.Map<LessonProfilDefinitionDto[]>(lessonsProfil);
            return Ok(mappedLessonsProfil);
        }



        /// <summary>
        /// Adds or updates a lessonprofil definition.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
     //   [ProducesResponseType(StatusCodes.Status409Conflict)]
        public ActionResult<LessonProfilDefinitionDto> AddOrUpdateLessonProfil([FromBody] LessonProfilDefinitionDto model)
        {
            if (ModelState.IsValid) 
            {
                //Das Modell ist dann valide, wenn es die per Annotation definierten
                //Eigenschaften erfüllt, ansonsten werden wir einen Fehler zurückliefern.

                //Wir "mappen" das gelieferte Modell zu unserer lokalen Domänen-Repräsentation
                var mappedModel = Mapper.Map<LessonProfilDefinition>(model);

               

                if (model.LessonProfilId == 0)
                { //add
                 // try { 
                        mappedModel = LessonProfilDefinitionService.AddLessonProfil(mappedModel);
                //    }catch
                    //{ 
                    //return Conflict(ModelState);
                    //}
                    }
                else
                { //update
                    mappedModel = LessonProfilDefinitionService.UpdateLessonProfil(mappedModel);
                }

                //Wir liefern das geänderte Objekt auch wieder zurück
                
                model = Mapper.Map<LessonProfilDefinitionDto>(mappedModel);
                return Ok(model);
            }
            return BadRequest(ModelState);
        }

        /// <summary>
        /// Removes a lessonprofil definition.
        /// </summary>
        /// <param name="lessonProfilId"></param>
        /// <returns></returns>
        [HttpDelete("{lessonProfilId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult DeleteLessonProfil([FromRoute] int lessonProfilId)
        {
            var lessonProfil = LessonProfilDefinitionService.GetLessonProfilWithid(lessonProfilId);
            if (lessonProfil == null) return StatusCode(StatusCodes.Status404NotFound);

            LessonProfilDefinitionService.RemoveLessonProfil(lessonProfil);
            return Ok();
        }
    }
}
