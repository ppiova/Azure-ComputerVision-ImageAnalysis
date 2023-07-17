# Azure Computer Vision Image Analysis App 🖼️🔍

## Description 📝

This is a .NET 6 console application that uses Azure Computer Vision 4.0 to analyze an image from a URL. The application extracts relevant information from the image, such as the image's height and width, the version of the model used for analysis, a caption automatically generated for the image, and a series of "dense captions", which are more detailed descriptions of different regions within the image. 🖥️🌐

## Requirements 🛠️

- .NET 6.0 SDK
- An Azure account with a key and endpoint for the Computer Vision service.

## Setup 🚀

For this application to work, you need to have an Azure account with access to the Computer Vision service. You should set up two environment variables on your system:

- `VISION_KEY`: Your Azure Computer Vision secret key. 🔑
- `VISION_ENDPOINT`: The endpoint of your Azure Computer Vision service. 🔗

## How to Use 🕹️

1. Clone this repository onto your local machine. 🔄
2. Open a terminal and navigate to the directory where the project is located. 🗂️
3. Run the command `dotnet run` to start the application. 🏃‍♂️

The application will analyze the image at the provided URL and display the extracted information in the console. 🖼️📊

## Output 📋

The application outputs the following information extracted from the image:

- The height and width of the image. 📏
- The version of the Azure Computer Vision model used for the analysis. 🤖
- A caption automatically generated for the image. 🗨️
- A series of "dense captions" for different regions of the image. 📝

Each dense caption includes the caption content, the bounding box of the region, and the confidence in the caption. 💡

## Contributions 🤝

Contributions are welcome. Feel free to open an Issue or make a Pull Request.

## 📄 License
This project is licensed under the terms of the MIT license.
