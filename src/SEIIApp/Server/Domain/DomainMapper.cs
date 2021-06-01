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

            //CreateMap<ProfilDefinition, ProfilDto>()
            //    .ForMember(profilDto => profilDto.Profile, opts => opts.MapFrom(obj => obj.Profile.ToArray()));
            //CreateMap<ProfilDto, ProfilDefinition>()
            //    .ForMember(profilObj => profilObj.Profile, opts => opts.MapFrom(dto => dto.Profile.ToList()));

            //CreateMap<QuizDefinition, QuizDefinitionBaseDto>();
            //CreateMap<QuizDefinition, QuizDefinition>();

            //CreateMap<QuestionDefinition, QuestionDefinitionDto>()
            //    .ForMember(questionDto => questionDto.Answers, opt => opt.MapFrom(obj => obj.Answers.ToArray()));
            //CreateMap<QuestionDefinitionDto, QuestionDefinition>()
            //    .ForMember(questionObj => questionObj.Answers, opt => opt.MapFrom(obj => obj.Answers.ToList()));

            CreateMap<ProfilDefinition, ProfilDefinitionDto>();
            CreateMap<ProfilDefinitionDto, ProfilDefinition>();

            CreateMap<LessonDefinition, LessonDefinitionDto>();
            CreateMap<LessonDefinitionDto, LessonDefinition>();

            CreateMap<MessageDefinition, MessageDefinitionDto>();
            CreateMap<MessageDefinitionDto, MessageDefinition>();

        }
    }
}
