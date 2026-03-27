using System;
using System.Collections.Generic;

namespace FlagQuiz
{
    /// <summary>
    /// Класс вопроса викторины
    /// </summary>
    public class Question
    {
        private string text;
        private string imagePath;
        private string hint;
        private List<string> answers;
        private int correctAnswerIndex;

        public Question()
        {
            answers = new List<string>();
            correctAnswerIndex = -1;
        }

        public string Text
        {
            get { return text; }
            set { text = value; }
        }

        public string ImagePath
        {
            get { return imagePath; }
            set { imagePath = value; }
        }

        public string Hint
        {
            get { return hint; }
            set { hint = value; }
        }

        public List<string> Answers
        {
            get { return answers; }
            set { answers = value; }
        }

        public int CorrectAnswerIndex
        {
            get { return correctAnswerIndex; }
            set { correctAnswerIndex = value; }
        }

        public string GetCorrectAnswer()
        {
            if (correctAnswerIndex >= 0 && correctAnswerIndex < answers.Count)
                return answers[correctAnswerIndex];
            return "";
        }

        public bool IsCorrect(int selectedIndex)
        {
            return selectedIndex == correctAnswerIndex;
        }
    }
}