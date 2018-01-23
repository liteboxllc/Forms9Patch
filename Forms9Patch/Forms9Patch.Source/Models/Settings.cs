﻿using System;
using System.Collections.Generic;
using System.Reflection;
using Xamarin.Forms;

namespace Forms9Patch
{
    /// <summary>
    /// Forms9Patch Settings (for use by Forms9Patch PCL code).
    /// </summary>
    public class Settings
    {
        static Settings()
        {
            P42.Utils.Environment.EmbeddedResourceAssemblyResolver = AssemblyExtensions.AssemblyFromResourceId;
        }

        /// <summary>
        /// The shadow offset.
        /// </summary>
        public static Point ShadowOffset = new Point(0, 1);

        /// <summary>
        /// The shadow radius.
        /// </summary>
        public static double ShadowRadius = 3;

        internal static TimeSpan MsUntilTapped = TimeSpan.FromMilliseconds(210);


        /// <summary>
        /// WidthRequest for ListView Cell swipe popup menu.
        /// </summary>
        public static double ListViewCellSwipePopupMenuWidthRequest = 250;
        /// <summary>
        /// FontSize for ListView Cell swipe popup menu text.
        /// </summary>
        public static double ListViewCellSwipePopupMenuFontSize = 16;
        /// <summary>
        /// Color for ListView Cell swipe popup menu text.
        /// </summary>
        public static Color ListViewCellSwipePopupMenuTextColor = Color.FromHex("0076FF");
        /// <summary>
        /// Color for background of ListView Cell swipe popup menu buttons.
        /// </summary>
        public static Color ListViewCellSwipePopupMenuButtonColor = Color.White;
        /// <summary>
        /// OutlineColor for background of ListView Cell swipe popup menu buttons.
        /// </summary>
        public static Color ListViewCellSwipePopupMenuButtonOutlineColor = Color.FromHex("CCC");
        /// <summary>
        /// OutlineWidth for background of ListView Cell swipe popup menu buttons.
        /// </summary>
        public static float ListViewCellSwipePopupMenuButtonOutlineWidth = 0;
        /// <summary>
        /// OutlineRadius for background of ListView Cell swipe popup menu buttons.
        /// </summary>
        public static float ListViewCellSwipePopupMenuButtonOutlineRadius = 6;
        /// <summary>
        /// SeparatorWidth for background of ListView Cell swipe popup menu buttons.
        /// </summary>
        public static float ListViewCellSwipePopupMenuButtonSeparatorWidth = 0;
        /// <summary>
        /// Are haptics active by default?
        /// </summary>
        public static KeyClicks KeyClicks = KeyClicks.Default;

        static string _licenseKey;

        /// <summary>
        /// Gets the license key.
        /// </summary>
        /// <value>The license key.</value>
        public static string LicenseKey
        {
            get
            {
                return _licenseKey;
            }
            internal set
            {
                _licenseKey = value;
            }
        }

        static bool _confirmed;
        internal static void ConfirmInitialization()
        {
            if (_confirmed)
                return;
            if (string.IsNullOrWhiteSpace(LicenseKey) && Application.Current != null)
                throw new Exception("Forms9Patch has not been initialized.  See http://http://buildcalc.com/forms9patch/index.html#HowToConfigureTheLicenseKey.  Xamarin.Forms.Application.Current=[" + Xamarin.Forms.Application.Current + "]");
            _confirmed = true;
        }

        static INativeSettings _nativeSettings;
        static INativeSettings NativeSettings
        {
            get
            {
                _nativeSettings = _nativeSettings ?? Xamarin.Forms.DependencyService.Get<INativeSettings>();
                return _nativeSettings;
            }
        }

        internal static List<Assembly> IncludedAssemblies => NativeSettings?.IncludedAssemblies;


    }
}
