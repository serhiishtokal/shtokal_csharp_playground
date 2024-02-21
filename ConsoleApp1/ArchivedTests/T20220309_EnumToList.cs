using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using ConsoleApp1.Interfaces;

namespace ConsoleApp1.ArchivedTests
{
    internal class T20220309_EnumToList: ITest
    {
        public void Test()
        {
            var list= Enum.GetNames(typeof(TestEnum));
            var list2 = new List<SelectListItem>();
            var k = list2.GetFromEnum<TestEnum>();

            Console.WriteLine(list);
        }

        
    }

    public static class EnumExtensions
    {
        public static string GetDisplayValue<T>(this T value) where T : struct
        {
            var fieldInfo = value.GetType().GetField(value.ToString());

            if (!(fieldInfo.GetCustomAttributes(
                typeof(DisplayAttribute), false) is DisplayAttribute[] descriptionAttributes)) return value.ToString();
            return (descriptionAttributes.Length > 0) ? descriptionAttributes[0].Name : value.ToString();
        }

        public static List<SelectListItem> GetFromEnum<T>(this List<SelectListItem> selectList, bool sortByText = true) where T : struct
        {
            var items = Enum.GetValues(typeof(T)).OfType<T>();
            selectList.AddRange(from item in items
                                let value = item.ToString()
                                let text = GetDisplayValue(item)
                                select new SelectListItem(value, text));
            if (sortByText)
            {
                selectList = selectList.OrderBy(x => x.Text).ToList();
            }
            return selectList;
        }

    }


    public class SelectListItem
    {
        public string Text { get; set; }
        public string Value { get; set; }

        public SelectListItem(string value, string text)
        {
            Value = value;
            Text = text;
        }

        public SelectListItem(Guid value, string text) : this(value.ToString().ToLowerInvariant(), text)
        {

        }
    }

    enum TestEnum
    {
        Position1,
        Position2,
        Position3,
        Position4
    }
}
