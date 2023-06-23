namespace ReportProgressTask
{
	internal class Program
	{
		static async Task Main(string[] args)
		{
			var progress = new Progress<double>();
			progress.ProgressChanged += (sender, args) =>
			{
				Console.WriteLine(value: $"Progress : {args}");
			};


			await MyMethodAsync(progress);
		}

		static async Task MyMethodAsync(IProgress<double> progress = null)
		{
			bool done = false;
			double percentComplete = 0;
			while (!done)
			{

				await Task.Delay(millisecondsDelay: 100);

				percentComplete++;

				progress?.Report(value: percentComplete);

				if (percentComplete > 99)
					done = true;

			}
		}
	}
}