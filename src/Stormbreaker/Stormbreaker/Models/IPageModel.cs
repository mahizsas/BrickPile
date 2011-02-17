using System.Collections.Generic;

namespace Stormbreaker.Models {
    /// <summary>
    /// Represents the page model
    /// </summary>
    public interface IPageModel : IDocumentModel {
        /// <summary>
        /// <see cref="PageModel.MetaData"/>
        /// </summary>
        IPageMetaData MetaData { get; }
        /// <summary>
        /// <see cref="PageModel.Parent"/>
        /// </summary>
        DenormalizedReference<IPageModel> Parent { get; set; }
        /// <summary>
        /// <see cref="PageModel.Children"/>
        /// </summary>
        IList<DenormalizedReference<IPageModel>> Children { get; }
    }
}