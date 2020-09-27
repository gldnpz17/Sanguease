using System.Collections.Generic;

namespace Sanguease.ViewCreator
{
    public interface IViewCreatorConfig
    {
        List<ViewCreatorEntry> viewCreatorEntries { get; set; }
    }
}