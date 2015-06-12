<%@ Control Language="vb" AutoEventWireup="false" Codebehind="DX_HoSoPhapLy.ascx.vb" Inherits="CPXD.DX_HoSoPhapLy" TargetSchema="http://schemas.microsoft.com/intellisense/ie3-2nav3-0" %>
<script language="javascript">
function TinhChenhLech(obj1,obj2,obj3)
{
	var kq;
	var a;
	var b;
	a=obj2.value;
	b=obj1.value;
	if((a!='')&&(b!=''))
	{
		kq=a-b;
		if (kq>0)
		{
			var rlength = 2;
			kq=Math.round(kq*Math.pow(10,rlength))/Math.pow(10,rlength);
			obj3.value=kq;
		}
	}
}
function TinhDienTichSan()
{
var obj;
var obj1;
var obj2;
var t;
	obj=document.all("_ctl0:_ctl0:_ctl0:DX_HoSoPhapLy1:txtHSPL_DienTichKhuonVienHienHuuTru");
	obj2=document.all("_ctl0:_ctl0:_ctl0:NoiDungGiayPhep:txtGP_DienTichXayDung");
	obj1=document.all("_ctl0:_ctl0:_ctl0:NoiDungGiayPhep:txtGP_DienTichSan");	
	//*alert(obj.value);
	if ((obj.value!='')&&(obj2.value!=''))
	{
		t=obj.value-obj2.value;
		var rlength = 2;//number of decima
		obj1.value=Math.round(t*Math.pow(10,rlength))/Math.pow(10,rlength);
		}
}
</script>
<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
	<TR>
		<TD vAlign="top" width="60%" height="300">
			<TABLE class="QH_Table" id="Table2" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD class="QH_ColLabel" colSpan="2" height="15"></TD>
				</TR>
				<TR>
					<TD class="QH_ColLabel" width="20%">Giấy phép sử dụng đất</TD>
					<TD class="QH_ColControl" width="*"><asp:textbox id="txtGP_GiaySuDungDat" tabIndex="26" Width="87%" MaxLength="500" CssClass="QH_Textbox"
							runat="server" TextMode="MultiLine"></asp:textbox>&nbsp;<asp:linkbutton id="LinkGiaySuDungDat" runat="server">Chọn...</asp:linkbutton></TD>
				</TR>
				<TR>
					<TD class="QH_ColLabel" width="20%">Diện tích khuôn viên pháp lý</TD>
					<TD class="QH_ColControl" width="*"><asp:textbox id="txtHSPL_DienTichKhuonVienGhiNhan" tabIndex="28" Width="87%" MaxLength="100"
							CssClass="QH_Textbox" runat="server"></asp:textbox></TD>
				</TR>
				<TR>
					<TD class="QH_ColLabel" width="20%">Diện tích khuôn viên hiện hữu</TD>
					<TD class="QH_ColControl" width="*"><asp:textbox id="txtHSPL_DienTichKhuonVienHienHuu" tabIndex="30" Width="87%" MaxLength="100"
							CssClass="QH_Textbox" runat="server"></asp:textbox></TD>
				</TR>
				<TR>
					<TD class="QH_ColLabel" width="20%">Diện tích khuôn viên hiện hữu (trừ)</TD>
					<TD class="QH_ColControl" width="*"><asp:textbox id="txtHSPL_DienTichKhuonVienHienHuuTru" tabIndex="30" Width="98%" MaxLength="100"
							CssClass="QH_Textbox" runat="server"></asp:textbox></TD>
				</TR>
				<TR>
					<TD class="QH_ColLabel" width="20%">DT chênh lệch</TD>
					<TD class="QH_ColControl" width="*"><asp:textbox id="txtHSPL_DienTichChenhLech" tabIndex="32" Width="87%" MaxLength="100" CssClass="QH_Textbox"
							runat="server">/</asp:textbox></TD>
				</TR>
				<TR>
					<TD class="QH_ColLabel" width="20%">Lý do chênh lệch</TD>
					<TD class="QH_ColControl" width="*"><asp:textbox id="txtHSPL_LyDoChenhLech" tabIndex="34" Width="87%" MaxLength="100" CssClass="QH_Textbox"
							runat="server" TextMode="MultiLine">/</asp:textbox>&nbsp;
						<asp:LinkButton id="LnkChenhLech" runat="server">Chọn</asp:LinkButton></TD>
				</TR>
				<TR>
					<TD class="QH_ColLabel" colSpan="2" height="15"></TD>
				</TR>
			</TABLE>
		</TD>
	</TR>
</TABLE>
