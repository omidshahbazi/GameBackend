using System.Windows.Forms.DataVisualization.Charting;

namespace Backend.Admin
{
	static class ChartUtilities
	{
		public static Series ConfigChartSeries(Chart Chart, string Title)
		{
			Series series = Chart.Series.Add(Title);

			series.ChartType = SeriesChartType.Spline;

			return series;
		}

		public static void AddAbsoluteValue(Series Series, ulong Value, int MaxSampleCount)
		{
			Series.Points.Add(Value);

			if (Series.Points.Count > MaxSampleCount)
				Series.Points.RemoveAt(0);
		}
	}
}
