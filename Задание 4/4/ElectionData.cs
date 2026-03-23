using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms.DataVisualization.Charting;

namespace WindowsFormsApp1
{
    /// <summary>
    /// Класс для хранения и обработки данных о выборах
    /// </summary>
    public class ElectionData
    {
        private List<District> districts;
        private string electionName;
        private int totalVoters;
        private int totalParticipated;
        private double averageParticipation;

        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public ElectionData()
        {
            districts = new List<District>();
            electionName = "Новые выборы";
            CalculateTotals();
        }

        /// <summary>
        /// Конструктор с загрузкой из файла
        /// </summary>
        public ElectionData(string fileName)
        {
            districts = new List<District>();
            LoadFromFile(fileName);
        }

        /// <summary>
        /// Список округов
        /// </summary>
        public List<District> Districts
        {
            get { return districts; }
        }

        /// <summary>
        /// Название выборов
        /// </summary>
        public string ElectionName
        {
            get { return electionName; }
            set { electionName = value; }
        }

        /// <summary>
        /// Общее количество избирателей
        /// </summary>
        public int TotalVoters
        {
            get { return totalVoters; }
        }

        /// <summary>
        /// Общее количество участвовавших
        /// </summary>
        public int TotalParticipated
        {
            get { return totalParticipated; }
        }

        /// <summary>
        /// Средний процент явки
        /// </summary>
        public double AverageParticipation
        {
            get { return averageParticipation; }
        }

        /// <summary>
        /// Количество округов
        /// </summary>
        public int Count
        {
            get { return districts.Count; }
        }

        /// <summary>
        /// Индексатор для доступа к округам
        /// </summary>
        public District this[int index]
        {
            get
            {
                if (index >= 0 && index < districts.Count)
                    return districts[index];
                else
                    return null;
            }
        }

        /// <summary>
        /// Добавление нового округа
        /// </summary>
        public void AddDistrict(District district)
        {
            districts.Add(district);
            CalculateTotals();
        }

        /// <summary>
        /// Добавление нового округа по параметрам
        /// </summary>
        public void AddDistrict(string name, int totalResidents, int participated)
        {
            districts.Add(new District(name, totalResidents, participated));
            CalculateTotals();
        }

        /// <summary>
        /// Удаление округа по индексу
        /// </summary>
        public void RemoveDistrict(int index)
        {
            if (index >= 0 && index < districts.Count)
            {
                districts.RemoveAt(index);
                CalculateTotals();
            }
        }

        /// <summary>
        /// Очистка всех данных
        /// </summary>
        public void Clear()
        {
            districts.Clear();
            CalculateTotals();
        }

        /// <summary>
        /// Вычисление общих показателей
        /// </summary>
        private void CalculateTotals()
        {
            totalVoters = districts.Sum(d => d.TotalResidents);
            totalParticipated = districts.Sum(d => d.Participated);

            if (districts.Count > 0)
            {
                averageParticipation = districts.Average(d => d.ParticipationPercent);
            }
            else
            {
                averageParticipation = 0;
            }
        }

        /// <summary>
        /// Сохранение данных в файл
        /// </summary>
        public void SaveToFile(string fileName)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(fileName))
                {
                    // Первая строка: название выборов
                    writer.WriteLine(electionName);

                    // Вторая строка: количество округов
                    writer.WriteLine(districts.Count);

                    // Далее: данные по каждому округу
                    foreach (District district in districts)
                    {
                        writer.WriteLine($"{district.Name},{district.TotalResidents},{district.Participated}");
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Ошибка при сохранении файла: {ex.Message}");
            }
        }

        /// <summary>
        /// Загрузка данных из файла
        /// </summary>
        public void LoadFromFile(string fileName)
        {
            try
            {
                using (StreamReader reader = new StreamReader(fileName))
                {
                    // Очищаем текущие данные
                    districts.Clear();

                    // Читаем название выборов
                    electionName = reader.ReadLine();

                    // Читаем количество округов
                    int count = int.Parse(reader.ReadLine());

                    // Читаем данные по каждому округу
                    for (int i = 0; i < count; i++)
                    {
                        string line = reader.ReadLine();
                        string[] parts = line.Split(',');

                        if (parts.Length == 3)
                        {
                            string name = parts[0];
                            int totalResidents = int.Parse(parts[1]);
                            int participated = int.Parse(parts[2]);

                            districts.Add(new District(name, totalResidents, participated));
                        }
                    }

                    CalculateTotals();
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Ошибка при загрузке файла: {ex.Message}");
            }
        }

        /// <summary>
        /// Построение круговой диаграммы
        /// </summary>
        public void BuildPieChart(Chart chart)
        {
            // Очистка предыдущих данных
            chart.Series.Clear();
            chart.Titles.Clear();

            // Настройка диаграммы
            chart.BackColor = System.Drawing.Color.White;
            chart.BorderlineColor = System.Drawing.Color.Gray;
            chart.BorderlineDashStyle = ChartDashStyle.Solid;

            // Настройка области диаграммы
            chart.ChartAreas.Clear();
            ChartArea chartArea = new ChartArea();
            chartArea.BackColor = System.Drawing.Color.White;
            chartArea.Area3DStyle.Enable3D = true;
            chartArea.Area3DStyle.Inclination = 30;
            chart.ChartAreas.Add(chartArea);

            // Добавление заголовка
            chart.Titles.Add($"{electionName}\nЯвка избирателей по округам");
            chart.Titles[0].Font = new System.Drawing.Font("Arial", 12, System.Drawing.FontStyle.Bold);

            // Создание серии для круговой диаграммы
            Series series = new Series();
            series.ChartType = SeriesChartType.Pie;
            series.Name = "Participation";

            // Добавление данных
            foreach (District district in districts)
            {
                int pointIndex = series.Points.AddXY(district.Name, district.Participated);
                series.Points[pointIndex].LegendText = $"{district.Name} ({district.ParticipationPercent:F1}%)";
                series.Points[pointIndex].Label = $"#{pointIndex + 1}";
                series.Points[pointIndex].Font = new System.Drawing.Font("Arial", 8);
            }

            // Настройка подписей
            series.Label = "#PERCENT{P0}";
            series.LegendText = "#AXISLABEL";

            // Добавление серии на диаграмму
            chart.Series.Add(series);

            // Настройка легенды
            chart.Legends.Clear();
            Legend legend = new Legend();
            legend.Docking = Docking.Bottom;
            legend.Alignment = System.Drawing.StringAlignment.Center;
            legend.Font = new System.Drawing.Font("Arial", 9);
            chart.Legends.Add(legend);
        }
    }
}