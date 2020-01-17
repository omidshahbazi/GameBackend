using System.Windows.Forms.DataVisualization.Charting;

namespace Backend.Admin
{
	static class ChartUtilities
	{
		private const int MAX_SAMPLES = 20;

		public static Series ConfigChartSeries(Chart Chart, string Title)
		{
			Series series = Chart.Series.Add(Title);

			series.ChartType = SeriesChartType.Spline;

			return series;
		}

		public static void AddAbsoluteValue(Series Series, ulong Value)
		{
			Series.Points.Add(Value);

			if (Series.Points.Count > MAX_SAMPLES)
				Series.Points.RemoveAt(0);
		}
	}
}
