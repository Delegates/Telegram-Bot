using System;
using System.Linq;
using System.Reflection;

namespace Bot.Parameters
{
    public class ParametersHandler<TParameters> : IParametersHandler<TParameters> where TParameters : IParameters, new()
    {
        private static dynamic Parser(string arg, Type type)
        {
            if (type == typeof (string)) return arg;
            if (type == typeof (int)) return int.Parse(arg);
            if (type == typeof (double)) return double.Parse(arg);
            throw new NotImplementedException($"Парсер для типа {type.FullName} не известен");
        }

        public TParameters CreateParameters(string[] value)
        {
            var parameters = new TParameters();
            var properties = typeof(TParameters)
                .GetProperties()
                .Where(z => z.GetCustomAttributes(typeof(ParameterInfo), false).Length > 0)
                .ToArray();
            if (properties.Length != value.Length) throw new ArgumentException();
            for (var i = 0; i < value.Length; i++)
            {
                properties[i].SetValue(parameters, Parser(value[i], properties[i].PropertyType), new object[0]);
            }
            return parameters;
        }
    }
}