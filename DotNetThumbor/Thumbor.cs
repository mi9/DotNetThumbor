﻿namespace DotNetThumbor
{
    using System;

    public class Thumbor : IThumbor
    {
        private readonly Uri thumborServerUrl;

        private Uri imageUrl;

        private string resizeWidthAndHeight;

        private bool smartImage;

        private ImageFormat outputFormat;

        public Thumbor(string thumborServerUrl)
        {
            this.thumborServerUrl = new Uri(thumborServerUrl);
        }

        public enum ImageFormat
        {
            None,
            Webp,
            Jpeg,
            Png,
            Gif
        }

        public Thumbor BuildImage(string imageUrl)
        {
            try
            {
                this.imageUrl = new Uri(imageUrl);
            }
            catch (UriFormatException ex)
            {
                throw new ArgumentException("Invalid URL", ex);
            }

            return this;
        }

        public Thumbor Resize(int? width, int? height)
        {
            width = width ?? 0;
            height = height ?? 0;

            this.resizeWidthAndHeight = width + "x" + height;
            return this;
        }

        public Thumbor Smart(bool smartImage)
        {
            this.smartImage = smartImage;
            return this;
        }

        public Thumbor Format(ImageFormat imageFormat)
        {
            this.outputFormat = imageFormat;
            return this;
        }

        public string ToUrl()
        {
            if (this.imageUrl == null)
            {
                throw new InvalidOperationException("BuildImage must be called before ToUrl");
            }

            var url = this.thumborServerUrl + "unsafe/";

            if (this.resizeWidthAndHeight != null)
            {
                url += this.resizeWidthAndHeight + "/";
            }

            if (this.smartImage)
            {
                url += "smart/";
            }

            if (this.outputFormat != ImageFormat.None)
            {
                url += string.Format("filters:format({0})/", this.outputFormat.ToString().ToLower());
            }

            return string.Format("{0}{1}", url, this.imageUrl);
        }


    }
}
