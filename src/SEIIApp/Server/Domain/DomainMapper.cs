using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using SEIIApp.Shared.DomainTdo;

namespace SEIIApp.Server.Domain
{
    public class DomainMapper : Profile
    {
        public DomainMapper()
        {



            CreateMap<ProfilDefinition, ProfilDefinitionDto>();
            CreateMap<ProfilDefinitionDto, ProfilDefinition>();

            CreateMap<ProfilDefinition, ProfilDefinitionDto>();
            CreateMap<ProfilDefinition, ProfilDefinition>();

            CreateMap<LessonProfilDefinition, LessonProfilDefinitionDto>();
            CreateMap<LessonProfilDefinitionDto, LessonProfilDefinition>();

            CreateMap<LessonProfilDefinition, LessonProfilDefinitionDto>();
            CreateMap<LessonProfilDefinition, LessonProfilDefinition>();

            CreateMap<LessonDefinition, LessonDefinitionDto>();
            CreateMap<LessonDefinitionDto, LessonDefinition>();

            CreateMap<LessonDefinition, LessonDefinitionDto>();
            CreateMap<LessonDefinition, LessonDefinition>();

            CreateMap<MessageDefinition, MessageDefinitionDto>();
            CreateMap<MessageDefinitionDto, MessageDefinition>();

            CreateMap<MessageDefinition, MessageDefinitionDto>();
            CreateMap<MessageDefinition, MessageDefinition>();

        }
    }
}
