using System;

namespace WindowsFormsApp1
{
    /// <summary>
    /// Класс, представляющий избирательный округ
    /// </summary>
    public class District
    {
        private string name;           // Название округа
        private int totalResidents;    // Количество жителей
        private int participated;      // Количество участвовавших в выборах
        private double participationPercent; // Процент участвовавших

        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public District()
        {
            name = "";
            totalResidents = 0;
            participated = 0;
            CalculateParticipationPercent();
        }

        /// <summary>
        /// Конструктор с параметрами
        /// </summary>
        public District(string name, int totalResidents, int participated)
        {
            this.name = name;
            this.totalResidents = totalResidents;
            this.participated = participated;
            CalculateParticipationPercent();
        }

        /// <summary>
        /// Название округа
        /// </summary>
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        /// <summary>
        /// Общее количество жителей
        /// </summary>
        public int TotalResidents
        {
            get { return totalResidents; }
            set
            {
                totalResidents = value;
                CalculateParticipationPercent();
            }
        }

        /// <summary>
        /// Количество участвовавших в выборах
        /// </summary>
        public int Participated
        {
            get { return participated; }
            set
            {
                participated = value;
                CalculateParticipationPercent();
            }
        }

        /// <summary>
        /// Процент участвовавших
        /// </summary>
        public double ParticipationPercent
        {
            get { return participationPercent; }
        }

        /// <summary>
        /// Вычисление процента участвовавших
        /// </summary>
        private void CalculateParticipationPercent()
        {
            if (totalResidents > 0)
            {
                participationPercent = (double)participated / totalResidents * 100;
            }
            else
            {
                participationPercent = 0;
            }
        }

        /// <summary>
        /// Переопределение метода ToString для отображения в списке
        /// </summary>
        public override string ToString()
        {
            return $"{name}: {participationPercent:F2}% явки";
        }
    }
}