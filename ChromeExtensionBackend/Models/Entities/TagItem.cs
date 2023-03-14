using System;
using System.Collections.Generic;

namespace ChromeExtensionBackend.Models.Entities;

public partial class TagItem
{
    public int TagItemId { get; set; }

    public string Time { get; set; } = null!;

    public string Selection { get; set; } = null!;

    public string Url { get; set; } = null!;

    public string Title { get; set; } = null!;

    public bool IsEditing { get; set; }

    public bool IsFlipped { get; set; }

    public bool IsShowing { get; set; }

    public string? MetaDescription { get; set; }

    public virtual ICollection<Tag> Tags { get; } = new List<Tag>();
}
