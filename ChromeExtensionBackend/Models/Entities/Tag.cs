using System;
using System.Collections.Generic;

namespace ChromeExtensionBackend.Models.Entities;

public partial class Tag
{
    public int Id { get; set; }

    public int TagItemId { get; set; }

    public string Tag1 { get; set; } = null!;

    public virtual TagItem TagItem { get; set; } = null!;
}
