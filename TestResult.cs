using System;

namespace SortScores
{
    internal class TestResult
    {
        public int Score { get; }

        public string FirstName { get; }

        public string LastName { get; }


        private static class Column
        {
            public const int LastName = 0;
            public const int FirstName = 1;
            public const int Score = 2;

            public const int MinColumns = Score + 1;
        }

        private TestResult(string lastName, string firstName, int score)
        {
            LastName = lastName;
            FirstName = firstName;
            Score = score;
        }

        public static TestResult FromString(string source)
        {
            var data = source.Split(',');

            if (data.Length != Column.MinColumns)
                return null;

            int score;

            if (!Int32.TryParse(data[Column.Score].Trim(), out score) || score < 0)
                return null;

            return new TestResult(data[Column.LastName].Trim(), data[Column.FirstName].Trim(), score);
        }
    }
}