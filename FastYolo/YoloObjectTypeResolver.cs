﻿using System.Collections.Generic;
using System.IO;

namespace FastYolo
{
	public class YoloObjectTypeResolver
	{
		public YoloObjectTypeResolver(string namesFilename) =>
			Initialize(File.ReadAllLines(namesFilename));

		public Dictionary<int, string> ObjectType { get; } = new();

		private void Initialize(string[] objectTypes)
		{
			for (var i = 0; i < objectTypes.Length; i++)
				ObjectType.Add(i, objectTypes[i]);
		}

		public string Resolve(int objectId) =>
			!ObjectType.TryGetValue(objectId, out var objectType)
				? "unknown key"
				: objectType;
	}
}