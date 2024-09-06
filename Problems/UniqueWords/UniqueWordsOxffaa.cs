using System.Diagnostics;
using Microsoft.CodeAnalysis.FlowAnalysis;
using Xunit;

namespace Problems.UniqueWords;

public sealed class UniqueWordsOxffaa
{
    /* Реализовать метод который посчитает кол-во уникальных слов в передаваемой ему строке.
        Определение что такое слово:  словом считается любое сочетание цифр и/или любых символов разделенных пробелом.
        Например: “abc someww1 123 abc someww1” => [abc, someww1, 123] - ответ 3

        Объем данных: Длина строки может быть [0; 500MB]

        Требования:
            - сигнатура метода `public static int CountUniqueWords(string source)`
            - метод должен корректно обрабатывать NullOrWhiteSpace строку
            - использовать static поля/свойства запрещено
            - реализовать максимально производительный метод в отдельном классе. Класс наименовать `UniqueWordsYourName`  например `UniqueWordsFuryslav`
            - Нельзя использовать параллелизм
    */

    public static int CountUniqueWords(string source)
    {
        if (String.IsNullOrWhiteSpace(source)) return 0;

        var words = source.Split(' ');
        var set = new HashSet<string>(words.Length);
        
        foreach (var word in words)
        {
            if (String.IsNullOrWhiteSpace(word)) continue;

            set.Add(word);
        }

        return set.Count;
    }

    [Theory]
    [InlineData(null, 0)]
    [InlineData("", 0)]
    [InlineData(" ", 0)]
    [InlineData("   ", 0)]
    [InlineData("abc someww1 123 abc someww1", 3)]
    [InlineData("ggggggggggggggggggggggggg SSSSSSSSSSSSSSSSSSSSSSSSS ttttttttttttttttttttttttt ", 3)]
    public void TestCases(string source, int count)
    {
        Assert.Equal(count, CountUniqueWords(source));
    }
}