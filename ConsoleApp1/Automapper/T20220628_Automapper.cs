using AutoMapper;
using ConsoleApp1.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Automapper
{
    internal class T20220628_Automapper : ITest
    {
        public void Test()
        {
            var mapper = CreateIMapper();
            var parent = new Parent("I am Parent");
            var children = Enumerable.Empty<Child>();
            for (int i = 0; i < 4; i++)
            {
                var child = new Child($"I am child {i + 1}");
                children = children.Append(child);
            }

            parent.ParentChildrenAssignments = children
                .Select(x => new ParentChildrenAssignment(x, DateTime.UtcNow))
                .ToArray();

            var parentDto = mapper.Map<ParentDto>(parent);
            
        }

        private IMapper CreateIMapper()
        {
            var config = new MapperConfiguration(InitMapperConfig);
            var mapper = config.CreateMapper();
            return mapper;

        }

        private void InitMapperConfig(IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<Parent, ParentDto>()
                .ForMember(x=>x.Children, y=>y.MapFrom(x=>x.ParentChildrenAssignments));


            cfg.CreateMap<ParentChildrenAssignment, ChildDto>()
                .ConvertUsing<ChildrenMappingConverter>();

            cfg.CreateMap<Child, ChildDto>();
        }

        private class ChildrenMappingConverter : ITypeConverter<ParentChildrenAssignment, ChildDto>
        {
            public ChildDto Convert(ParentChildrenAssignment source, ChildDto destination, ResolutionContext context)
            {
                var k = context.Mapper.Map<ChildDto>(source.Child);
                k.AssignmentDate = source.AssignmentDate;
                return k;
            }
        }
    }

    internal class Parent
    {
        public string Name { get; set; }
        public IEnumerable<ParentChildrenAssignment> ParentChildrenAssignments { get; set; }

        public Parent(string name)
        {
            Name = name;
        }
    }

    internal class ParentChildrenAssignment
    {
        public Child Child { get; set; }
        public DateTime AssignmentDate { get; set; }

        public ParentChildrenAssignment(Child child, DateTime assignmentDate)
        {
            Child = child;
            AssignmentDate = assignmentDate;
        }
    }

    internal class Child
    {
        public string Name { get; set; }

        public Child(string name)
        {
            Name = name;
        }
    }
    /// <summary>
    /// /////////////
    /// </summary>
    internal class ParentDto
    {
        public string Name { get; set; }
        public IEnumerable<ChildDto> Children { get; set; }
    }

    internal class ChildDto
    {
        public DateTime AssignmentDate { get; set; }
        public string Name { get; set; }
    }

}
