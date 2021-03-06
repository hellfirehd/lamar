﻿using Shouldly;
using StructureMap.Building;
using StructureMap.Testing.Acceptance;
using System.Reflection;
using Xunit;

namespace StructureMap.Testing.Building
{
    public class ConstructorStepTester
    {
        private readonly ConstructorInfo[] ctors = typeof(ClassWithCtors).GetConstructors();

        [Fact]
        public void build_ctor_description_with_no_args()
        {
            ConstructorStep.ToDescription(ctors[0])
                .ShouldBe("new ClassWithCtors()");
        }

        [Fact]
        public void ctor_description_with_single_simple_arg()
        {
            ConstructorStep.ToDescription(ctors[1])
                .ShouldBe("new ClassWithCtors(String name)");
        }

        [Fact]
        public void ctor_description_with_multiple_simple_arg()
        {
            ConstructorStep.ToDescription(ctors[2])
                .ShouldBe("new ClassWithCtors(String name, Int32 age)");
        }

        [Fact]
        public void ctor_description_with_service_arg()
        {
            ConstructorStep.ToDescription(ctors[3])
                .ShouldBe("new ClassWithCtors(IWidget)");
        }

        [Fact]
        public void ctor_description_with_multiple_service_arg_of_the_same_type()
        {
            ConstructorStep.ToDescription(ctors[4])
                .ShouldBe("new ClassWithCtors(IWidget widget1, IWidget widget2)");
        }

        [Fact]
        public void ctor_description_with_mixed_services_and_simples()
        {
            ConstructorStep.ToDescription(ctors[5])
                .ShouldBe("new ClassWithCtors(IWidget, IService, String name)");
        }
    }

    public class ClassWithCtors
    {
        public ClassWithCtors()
        {
        }

        public ClassWithCtors(string name)
        {
        }

        public ClassWithCtors(string name, int age)
        {
        }

        public ClassWithCtors(IWidget widget)
        {
        }

        public ClassWithCtors(IWidget widget1, IWidget widget2)
        {
        }

        public ClassWithCtors(IWidget widget, IService service, string name)
        {
        }
    }
}