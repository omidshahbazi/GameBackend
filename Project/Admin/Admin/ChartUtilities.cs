using System.Windows.Forms.DataVisualization.Charting;

namespace Backend.Admin
{
	static class ChartUtilities
	{
		public static Series ConfigChartSeries(Chart Chart, string Title)
		{
			Series series = Chart.Series.Add(Title);

			series.Points.Add(0);

			series.ChartType = SeriesChartType.Spline;

			return series;
		}
	}
}
