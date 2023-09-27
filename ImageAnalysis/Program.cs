using Azure;
using Azure.AI.Vision.Common;
using Azure.AI.Vision.ImageAnalysis;


class Program
{
    static async Task Main(string[] args)
    {
        await AnalyzeImageAsync();
    }
    public static async Task AnalyzeImageAsync()
    {
        var key = Environment.GetEnvironmentVariable("VISION_KEY_FLORENCEDEMOS");
        var serviceOptions = new VisionServiceOptions(
                Environment.GetEnvironmentVariable("VISION_ENDPOINT_FLORENCEDEMOS"),
                new AzureKeyCredential(key));

        using var imageSource = VisionSource.FromUrl(new Uri("https://raw.githubusercontent.com/ppiova/Azure-ComputerVision-BackgroundRemoval/main/Images/RiseoftheResistance.jpg"));

        var analysisOptions = new ImageAnalysisOptions()
        {
            Features = ImageAnalysisFeature.Caption
                //| ImageAnalysisFeature.CropSuggestions
                //| ImageAnalysisFeature.Objects
                //| ImageAnalysisFeature.People
                //| ImageAnalysisFeature.Text
                //| ImageAnalysisFeature.Tags
                | ImageAnalysisFeature.DenseCaptions,
            Language = "en",
            ModelVersion = "latest",
            GenderNeutralCaption = true
        };

        using var analyzer = new ImageAnalyzer(serviceOptions, imageSource, analysisOptions);

        var result = await analyzer.AnalyzeAsync();

        if (result.Reason == ImageAnalysisResultReason.Analyzed)
        {

            Console.WriteLine($" Image height = {result.ImageHeight}");
            Console.WriteLine($" Image width = {result.ImageWidth}");
            Console.WriteLine($" Model version = {result.ModelVersion}");
            Console.WriteLine("-------------------------------------------------------------------------------");
            if (result.Caption != null)
            {
                Console.WriteLine(" Caption:");
                Console.WriteLine($"   \"{result.Caption.Content}\", Confidence {result.Caption.Confidence:0.0000}");
            }
            Console.WriteLine("-------------------------------------------------------------------------------");
            if (result.DenseCaptions != null)
            {
                Console.WriteLine(" Dense Captions:");
                Console.WriteLine(" Content     | Bounding Box     | Confidence");


                foreach (var caption in result.DenseCaptions)
                {
                    Console.WriteLine($"   {caption.Content}  |  {caption.BoundingBox}  |  {caption.Confidence:0.0000}");
                }
            }

        }


    }

}
