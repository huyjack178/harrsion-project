// <auto-generated />

using Fanex.BetList.Core.App_GlobalResources;

#region!!!This file is auto-generated by TplBuilder, don't modify it manually!!!

using System;
using System.Web;
using System.Text;
using TplCore;
using TplCore.Element;
#pragma warning disable
namespace Fanex.BetList.Core
{
	using Templates;
	namespace Templates
	{
		public class Trans_Template : Template
		{
			public Trans_TransTime_Block TransTime = new Trans_TransTime_Block();
			protected static string s0 = "<div class=\"time\">";
			public string transTime = "{transTime}";
			protected static string s1 = "</div>";
			public override void ToString(ref StringBuilder bd)
			{
				if(!Visible) return;
				if(RenderChild)
				{
					if(null != TransTime) TransTime.ToString(ref bd);
					bd.Append(s0);
					bd.Append(transTime);
					bd.Append(s1);
				}
				if(IsAssigned){bd.Append(Value);}
			}
			public string ToString()
			{
				StringBuilder bd = new StringBuilder();
				ToString(ref bd);
				return bd.ToString();
			}

		}

		public class Trans_TransTime_Block: Block
		{
			protected static string s2{get{return CoreBetList.refno;}}
			protected static string s3 = ": ";
			public string refNo = "{refNo}";
			public override void ToString(ref StringBuilder bd)
			{
				if(!Visible) return;
				if(RenderChild)
				{
					bd.Append(s2);
					bd.Append(s3);
					bd.Append(refNo);
				}
				if(IsAssigned){bd.Append(Value);}
			}
		}

	}
}
#pragma warning enable
#endregion