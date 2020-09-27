using System;
using System.Windows.Controls;

namespace Sanguease.ViewCreator
{
    public interface IViewCreator
    {
        UserControl GetInstance(string key);
    }
}