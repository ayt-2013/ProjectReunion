﻿// Copyright (c) Microsoft Corporation.
// Licensed under the MIT license.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using Microsoft.ApplicationModel.Resources;
using winui_class_lib;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace winui_desktop_packaged_app
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        public MainWindow(ResourceLoader resourceLoader, ResourceManager resourceManager)
        {
            m_resourceLoader = resourceLoader;
            m_resourceManager = resourceManager;

            // Create custom resource context for the window. Set the language to German.
            m_resourceContext = resourceManager.CreateResourceContext();
            m_resourceContext.QualifierValues["Language"] = "de-DE";
            
            this.InitializeComponent();            
        }

        private void default_Click(object sender, RoutedEventArgs e)
        {
            // The resource loader's default constructor assumes that resources are in the "Resources" scope.
            // Use the non-default constructor to load resources in a different scope.

            var resourceString = m_resourceLoader.GetString("SampleString");
            output.Text = resourceString;
        }

        private void override_Click(object sender, RoutedEventArgs e)
        {
            // The resource manager does not have a default scope and resolves resources based on the root.

            var resourceCandidate = m_resourceManager.MainResourceMap.GetValue("Resources/SampleString", m_resourceContext);
            var resourceString = resourceCandidate.ValueAsString;

            output.Text = resourceString;
        }

        private void fallback_Click(object sender, RoutedEventArgs e)
        {
            var resourceCandidate = m_resourceManager.MainResourceMap.GetValue("LegacyString");
            var resourceString = resourceCandidate.ValueAsString;

            output.Text = resourceString;
        }

        private void defaultViaLib_Click(object sender, RoutedEventArgs e)
        {
            var libClass = new winui_class_lib_class();
            output.Text = libClass.GetDefaultSampleString();
        }

        private ResourceLoader m_resourceLoader;
        private ResourceManager m_resourceManager;
        private ResourceContext m_resourceContext;
    }
}