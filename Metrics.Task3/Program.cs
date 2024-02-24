using System.Text.RegularExpressions;

char[] divs = { '\n' };
var codeLines = File.ReadAllText("code.txt").Split(divs, StringSplitOptions.RemoveEmptyEntries);
var totalLines = codeLines.Length;
Console.WriteLine($"Число физических строк - {totalLines}");

var logicalLines = codeLines.Sum(line => RegexHelper.LogicalOperatorsRegex().Count(line));
Console.WriteLine($"Число логических строк - {logicalLines}");

var commentRowsCount = codeLines.Count(line => line.Contains("//"));
Console.WriteLine($"Число строк коментариев - {commentRowsCount}");

var levelOfCodeCommentability = commentRowsCount / (double)totalLines;
Console.WriteLine($"Уровень комментируемости кода - {levelOfCodeCommentability}");
partial class RegexHelper
{
    [GeneratedRegex(@"(((for)|(if)|(elif))\s+\(.+\))|(\S.+;)|(else)")]
    public static partial Regex LogicalOperatorsRegex();
}