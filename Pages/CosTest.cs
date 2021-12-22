using Microsoft.AspNetCore.Components;
using Any2pdf.Core;
using System.Collections.Generic;
//using System.Diagnostics;// Debug.WriteLine

namespace cosTest.Pages {
  public partial class CosTest : ComponentBase
  {
	protected int CosFixedCount { get; set; } = 0;
	protected float _v;
	protected float CosFixedValue { get; set; } = 0;
	protected int CosDictCount { get; set; } = 0;
	private List<CosDict> _list;
	protected CosDict CosDict1 { get; set; } 


	protected void TestCosFixed()
	{
	  this.CosFixedCount++;
	  _v += 0.1f;
	  CosFixed csf= _v;
	  this.CosFixedValue=csf.FloatValue();
	}

	protected void TestCosDict()
	{
	  CosDict dict= new CosDict();
	  _list.Add(dict);
	  this.CosDictCount++;

	}

	protected void TestCosDict1()
	{
	  CosDict dict= new CosDict();
	  dict["k1"]= "v1";
	  dict["k2"]= 2; 
	  dict["k3"]= 3.33;
	  this.CosDict1=dict;
	  Console.WriteLine($"Message 1, Console.WriteLine, {dict.ToString()}");
	  //Debug.WriteLine($"Message 2, Debug.WriteLine, {this.CosDict1_str}");
	  Logger.LogInformation($"{dict.ToString()}");
	}

	protected override async Task OnInitializedAsync()
	{
	  this.CosFixedCount = 0;
	  this.CosDictCount=0;
	  _v=5.0f;
	  _list= new List<CosDict>();
	  this.CosDict1= new CosDict();
	}
  }
}
