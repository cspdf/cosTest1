using Microsoft.AspNetCore.Components;
using Any2pdf.Core;
using System.Collections.Generic;

namespace cosTest.Pages {
  public partial class Counter : ComponentBase
  {
	protected int CurrentCount { get; set; } = 0;
	protected int CosDictCount { get; set; } = 0;
	private List<CosDict> _list;

	protected void IncrementCount()
	{
	  this.CurrentCount++;
	}
	protected void IncrementCosDict()
	{
	  CosDict dict= new CosDict();
	  _list.Add(dict);
	  this.CosDictCount++;

	}

	protected override async Task OnInitializedAsync()
	{
	  this.CurrentCount = 10;
	  _list= new List<CosDict>();

	}
  }
}
