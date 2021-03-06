// <copyright file="BinaryNumberDisplayTest.cs">Copyright ©  2018</copyright>
using System;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProgrammingAlgorithom.Solution;

namespace ProgrammingAlgorithom.Solution.Tests
{
    /// <summary>This class contains parameterized unit tests for BinaryNumberDisplay</summary>
    [PexClass(typeof(BinaryNumberDisplay))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [TestClass]
    public partial class BinaryNumberDisplayTest
    {


    }
}
