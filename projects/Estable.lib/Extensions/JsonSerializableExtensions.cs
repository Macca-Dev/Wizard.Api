using Estable.Lib.Contracts;
using System.Text;
using System.Runtime.Serialization.Json;
using System.IO;

namespace Estable.Lib.Extensions
{
	public static class JsonSerializableExtensions
	{
		public static string ToJson<T>(this JsonSerializable obj)
		{
			using (var stream = new MemoryStream())
			{
				var serializer = new DataContractJsonSerializer(typeof(T));
				serializer.WriteObject(stream, obj);
				return Encoding.UTF8.GetString(stream.ToArray());
			}
		}

		public static T FromJson<T>(this string obj) where T : new()
		{
			if (obj.IsNullOrEmpty())
			{
				return new T();
			}

			using (var stream = new MemoryStream(Encoding.UTF8.GetBytes(obj)))
			{
				var serializer = new DataContractJsonSerializer(typeof(T));
				return (T)serializer.ReadObject(stream);
			}
		}
	}
}
