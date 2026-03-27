using System;

namespace DictionaryLibrary
{
    /// <summary>
    /// Класс для вычисления расстояния Левенштейна
    /// </summary>
    public static class Levenshtein
    {
        /// <summary>
        /// Вычисляет расстояние Левенштейна между двумя строками
        /// </summary>
        public static int Distance(string s, string t)
        {
            if (string.IsNullOrEmpty(s))
                return string.IsNullOrEmpty(t) ? 0 : t.Length;

            if (string.IsNullOrEmpty(t))
                return s.Length;

            int n = s.Length;
            int m = t.Length;
            int[,] d = new int[n + 1, m + 1];

            // Инициализация
            for (int i = 0; i <= n; d[i, 0] = i++) ;
            for (int j = 0; j <= m; d[0, j] = j++) ;

            // Вычисление расстояния
            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= m; j++)
                {
                    int cost = (t[j - 1] == s[i - 1]) ? 0 : 1;

                    d[i, j] = Math.Min(
                        Math.Min(d[i - 1, j] + 1, d[i, j - 1] + 1),
                        d[i - 1, j - 1] + cost);
                }
            }

            return d[n, m];
        }

        /// <summary>
        /// Проверяет, можно ли получить одну строку из другой заменой одной буквы
        /// </summary>
        public static bool CanGetByOneReplace(string source, string target)
        {
            // Длина должна быть одинаковой
            if (source.Length != target.Length)
                return false;

            int diffCount = 0;
            for (int i = 0; i < source.Length; i++)
            {
                if (source[i] != target[i])
                    diffCount++;
                if (diffCount > 1)
                    return false;
            }

            return diffCount == 1;
        }

        /// <summary>
        /// Проверяет, можно ли получить одну строку из другой за одну операцию
        /// (замена, вставка, удаление)
        /// </summary>
        public static bool CanGetByOneOperation(string source, string target)
        {
            return Distance(source, target) <= 1;
        }
    }
}