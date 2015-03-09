﻿namespace DotNetThumbor
{
    public interface IThumbor
    {
        Thumbor BuildImage(string imageUrl);

        Thumbor Resize(int? width, int? height);

        Thumbor Smart(bool smartImage);

        Thumbor Format(Thumbor.ImageFormat imageFormat);

        Thumbor Crop(int topLeft, int topRight, int bottomLeft, int bottomRight);

        Thumbor Quality(int? quality);

        Thumbor Grayscale(bool grayscaleImage);

        Thumbor Watermark(string imageUrl, int right, int down, int transparency);

        Thumbor Watermark(Thumbor thumborImage, int right, int down, int transparency);

        Thumbor Fill(string fillColour);

        Thumbor Trim(bool trimImage);

        Thumbor FitIn(bool fitIn);

        Thumbor FullFitIn(bool fullFitIn);

        string ToUrl();
    }
}
