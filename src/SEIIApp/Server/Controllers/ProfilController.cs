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
    [Route("api/profildefinitions")]
    public class ProfilDefinitionController : ControllerBase
    {

        private ProfilDefinitionService ProfilDefinitionService { get; set; }
        private IMapper Mapper { get; set; }

        public ProfilDefinitionController(ProfilDefinitionService profilDefinitionService, IMapper mapper)
        {
            this.ProfilDefinitionService = profilDefinitionService;
            this.Mapper = mapper;
        }

        /// <summary>
        /// Return the profil with the given id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Shared.DomainTdo.ProfilDefinitionDto> GetProfil([FromRoute] int id)
        {
            var profil = ProfilDefinitionService.GetProfilWithId(id);
            if (profil == null) return StatusCode(StatusCodes.Status404NotFound);

            var mappedProfil = Mapper.Map<ProfilDefinitionDto>(profil);
            return Ok(mappedProfil);
        }

        /// <summary>
        /// Returns all quizzes names and ids.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        //public ActionResult<ProfilDefinitionBaseDto[]> GetAllQuizes()
        //{
        //    var quizzes = ProfilDefinitionService.GetAllProfiles();
        //    var mappedQuizzes = Mapper.Map<ProfilDefinitionBaseDto[]>(quizzes);
        //    return Ok(mappedQuizzes);
        //}
        public ActionResult<ProfilDefinitionDto[]> GetAllProfile()
        {
            var profile = ProfilDefinitionService.GetAllProfile();
            var mappedProfile = Mapper.Map<ProfilDefinitionDto[]>(profile);
            return Ok(mappedProfile);
        }

        /// <summary>
        /// Adds or updates a profil definition.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<ProfilDefinitionDto> AddOrUpdateProfil([FromBody] ProfilDefinitionDto model)
        {
            if (ModelState.IsValid)
            {
                //Das Modell ist dann valide, wenn es die per Annotation definierten
                //Eigenschaften erfüllt, ansonsten werden wir einen Fehler zurückliefern.

                //Wir "mappen" das gelieferte Modell zu unserer lokalen Domänen-Repräsentation
                var mappedModel = Mapper.Map<ProfilDefinition>(model);

                if (model.Id == 0)
                { //add
                    mappedModel = ProfilDefinitionService.AddProfil(mappedModel);
                }
                else
                { //update
                    mappedModel = ProfilDefinitionService.UpdateProfil(mappedModel);
                }

                //Wir liefern das geänderte Objekt auch wieder zurück
                model = Mapper.Map<ProfilDefinitionDto>(mappedModel);
                return Ok(model);
            }
            return BadRequest(ModelState);
        }

        /// <summary>
        /// Removes a profil definition.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult DeleteProfil([FromRoute] int id)
        {
            var profil = ProfilDefinitionService.GetProfilWithId(id);
            if (profil == null) return StatusCode(StatusCodes.Status404NotFound);

            ProfilDefinitionService.RemoveProfil(profil);
            return Ok();
        }
    }
}
