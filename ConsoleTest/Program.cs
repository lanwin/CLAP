﻿using System;
using System.Diagnostics;
using System.Threading;
using CLAP;
using CLAP.Validation;

namespace ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Parser<MyApp>.Run(args);
        }
    }

    class MyApp
    {
        [Empty, Help]
        public static void Help(string help)
        {
            Console.WriteLine(help);
        }
    }

    //class MyApp
    //{
    //    [Empty]
    //    public static void Foo()
    //    {
    //    }
    //}

    //class MyApp
    //{
    //    [Help]
    //    public static void Help(string help)
    //    {
    //        Console.WriteLine(help);
    //    }

    //    [Verb]
    //    public static void Foo(string bar)
    //    {
    //    }
    //}

    //class MyApp
    //{
    //    [Help("h")]
    //    public static void Help(string help)
    //    {
    //        Console.WriteLine(help);
    //    }
    //}

    //class MyApp
    //{
    //    [Help(Aliases = "h,?")]
    //    public static void Help(string help)
    //    {
    //        Console.WriteLine(help);
    //    }
    //}


    //p.RegisterParameterHandler(
    //"debug,d,break",
    //delegate { Debugger.Launch(); },
    //"Attach a debugger to the process");

    //        p.RegisterHelpHandler("help,?", help => Console.WriteLine(help));

    //        p.RegisterParameterHandler<string>(
    //            "thread",
    //            name => Thread.CurrentThread.Name = name);

    //        p.RegisterParameterHandler<ThreadPriority>(
    //            "priority",
    //            priority => Thread.CurrentThread.Priority = priority);

    //        p.RegisterParameterHandler<int>(
    //            "number",
    //            number => Console.WriteLine("A number: {0}", number));

    //        p.RunWith(args);
    //    }
    //}

    class LengthValidationAttribute : ValidationAttribute
    {
        public int Length { get; private set; }

        public LengthValidationAttribute(int length)
            : base(new LengthValidator(length))
        {
            Length = length;
        }

        public override string Description
        {
            get
            {
                return string.Format(
                    "Length is at least {0}", Length);
            }
        }

        class LengthValidator : IParameterValidator
        {
            public int Length { get; private set; }

            public LengthValidator(int length)
            {
                Length = length;
            }

            public void Validate(object value)
            {
                var str = (string)value;

                if (str.Length < Length)
                {
                    throw new ValidationException(
                        string.Format(
                            "Length should be at least {0}",
                            Length));
                }
            }
        }
    }


    //class Test
    //{
    //    [Verb]
    //    public static void Foo([CLAP.Validation.RegexMatches("")]string name)
    //    {
    //        Console.WriteLine("name={0}", name);
    //    }

    //    // single string overrides the name
    //    // additional names are additional

    //    // exe -d
    //    // exe -bar:arg
    //    // exe -b:arg

    //    [Global("d")]
    //    public static void Debug()
    //    {
    //        Debugger.Launch();
    //    }

    //    [Global(Aliases = "b")]
    //    public static void Bar(string arg)
    //    {
    //        Console.WriteLine("bar={0}", arg);
    //    }
    //}

    //class MyApp
    //{
    //    [Verb]
    //    public static void Print(string prefix, string name, int count)
    //    {
    //        for (int i = 0; i < count; i++)
    //        {
    //            Console.WriteLine("{0} {1}", prefix, name);
    //        }
    //    }
    //}

    //[DefaultVerb("print")]
    //class MyApp
    //{
    //    [Verb]
    //    public static void Print(string prefix, string name, int count)
    //    {
    //    }

    //    [Verb]
    //    public static void Login(string userName, string password)
    //    {
    //    }
    //}

    //[DefaultVerb("print")]
    //class MyApp
    //{
    //    [Verb(Aliases = "p")]
    //    public static void Print(string prefix, string name, int count)
    //    {
    //    }

    //    [Verb(Aliases = "l,log")]
    //    public static void Login(string userName, string password)
    //    {
    //    }
    //}

    //class MyApp
    //{
    //    [Verb]
    //    public static void Login(
    //        [Parameter(Aliases = "name,n")]
    //        string userName,
    //        [Parameter(Aliases = "pass,p")]
    //        string password)
    //    {
    //    }
    //}


    //class MyApp
    //{
    //    [Verb]
    //    public static void Print(
    //        [Parameter(Default = "Hello")]
    //        string prefix,
    //        string name,
    //        [Parameter(Default = 5)]
    //        int count,
    //        [Parameter(Aliases = "u")]
    //        bool upper)
    //    {
    //        if (upper)
    //        {
    //            prefix = prefix.ToUpper();
    //            name = name.ToUpper();
    //        }

    //        for (int i = 0; i < count; i++)
    //        {
    //            Console.WriteLine("{0} {1}", prefix, name);
    //        }
    //    }
    //}

    //class MyApp
    //{
    //    [Verb]
    //    public static void Hello(string[] names)
    //    {
    //        foreach (var name in names)
    //        {
    //            Console.WriteLine("Hello {0}", name);
    //        }
    //    }
    //}

    //class MyApp
    //{
    //    [Verb]
    //    public static void Print(
    //        [Parameter(Default = "Hello")]
    //        string prefix,
    //        [Parameter(Required = true)]
    //        string name)
    //    {
    //    }
    //}

    //class MyApp
    //{
    //    [Verb]
    //    public static void Print(
    //        string prefix,
    //        string name,
    //        [Parameter(Required = true)]
    //        [MoreThan(3)]
    //        [LessOrEqualTo(20)]
    //        int count)
    //    {
    //        for (int i = 0; i < count; i++)
    //        {
    //            Console.WriteLine("{0} {1}", prefix, name);
    //        }
    //    }
    //}

    //class MyApp
    //{
    //    [Verb(Description = "Print something")]
    //    public static void Print(
    //        [LengthValidation(10)]
    //        [Parameter(Description = "A prefix", Aliases = "p")]
    //        string prefix,

    //        [Parameter(Description = "A name", Default = "Adrian", Aliases = "n")]
    //        string name,

    //        [LessThan(10)]
    //        [Parameter(Description = "A count", Required = true, Aliases = "c")]
    //        int count,

    //        bool one)
    //    {
    //        if (one)
    //        {
    //            Console.WriteLine(name);
    //        }
    //        else
    //        {
    //            for (int i = 0; i < count; i++)
    //            {
    //                Console.WriteLine(name);
    //            }
    //        }
    //    }

    //    [Empty]
    //    public static void Help(string help, int x)
    //    {
    //        Console.WriteLine(help);
    //    }

    //    public static void Nothing()
    //    {
    //        Console.WriteLine("Nothing?");
    //    }

    //    [Verb]
    //    public static void Login(string userName, string password)
    //    {
    //    }

    //    [Global("break")]
    //    public static void Debug()
    //    {
    //        Debugger.Launch();
    //    }

    //    [Global("thread")]
    //    public static void SetThreadName(string name)
    //    {
    //        Thread.CurrentThread.Name = name;
    //    }

    //    [Global("priority")]
    //    public static void SetThreadPriority(
    //        [Parameter(Description = "The thread's priority")]
    //        ThreadPriority priority)
    //    {
    //        Thread.CurrentThread.Priority = priority;
    //    }

    //    [Global("number")]
    //    public static void DoSomethingWithAnumber([LessThan(10)] int number)
    //    {
    //        Console.WriteLine("A number: {0}", number);
    //    }
    //}

}
