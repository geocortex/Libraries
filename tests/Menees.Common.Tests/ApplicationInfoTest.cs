﻿using System;
using System.Diagnostics;
using System.IO;
using Menees;
using Menees.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Menees.Common.Tests
{
	[TestClass()]
	public class ApplicationInfoTest
	{
		[TestMethod()]
		public void InitializeApplicationNameTest()
		{
			// Before Initialize is called, the app name gets pulled from AppDomain.FriendlyName
			string applicationName = ApplicationInfo.ApplicationName;
			Assert.IsNotNull(applicationName);

			applicationName = "Testing";
			ApplicationInfo.Initialize(applicationName);
			Assert.AreEqual(applicationName, ApplicationInfo.ApplicationName);
		}

		[TestMethod()]
		public void BaseDirectoryTest()
		{
			string expected = AppDomain.CurrentDomain.BaseDirectory;
			string actual = ApplicationInfo.BaseDirectory;
			Assert.AreEqual(expected, actual);
		}

		[TestMethod()]
		public void ExecutableFileTest()
		{
			string actual = ApplicationInfo.ExecutableFile;
			Assert.IsTrue(!string.IsNullOrEmpty(actual), "The file path is non-empty.");
			Assert.AreEqual(".exe", Path.GetExtension(actual), true);
		}

		[TestMethod]
		public void ProcessIdTest()
		{
			using (Process current = Process.GetCurrentProcess())
			{
				int expected = current.Id;
				int actual = ApplicationInfo.ProcessId;
				Assert.AreEqual(expected, actual);
			}
		}
	}
}
