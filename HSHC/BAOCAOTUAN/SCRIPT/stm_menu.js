<!--
///////////////////////////////// MENU DANH CHO CAC TRANG TRONG //////////////////////////////////////////

sRootFolder="/English/";
//sDictionary = "http://fpt-ssv:8080/"
sDictionary = "javascript:openForm();"
//Menu object creation
oCMenu=new makeCM("oCMenu") //Making the menu object. Argument: menuname

//Menu properties   
oCMenu.pxBetween=0
//Using the cm_page object to place the menu ----
  //There are some differences between the browsers that I try to fix here.
//oCMenu.fromLeft=!bw.ns4?cmpage.x2 - 160:cmpage.x2
oCMenu.fromLeft=(cmpage.x2-780)/2


//We also need to "replace" the menu on resize. So:
//oCMenu.onresize="oCMenu.fromLeft=cmpage.x2 - 160"
oCMenu.onresize="oCMenu.fromLeft = (cmpage.x2-780)/2"
//oCMenu.onresize=(cmpage.x2-780)/2


oCMenu.fromTop=67
//oCMenu.fromLeft=60  
oCMenu.rows=1
oCMenu.menuPlacement=0
                                                             
oCMenu.onlineRoot="" 
oCMenu.resizeCheck=1 
oCMenu.wait=1000 
oCMenu.fillImg="Images/cm_fill.gif"
oCMenu.zIndex=1000

//Background bar properties
oCMenu.useBar=1
oCMenu.barWidth="menu"
oCMenu.barHeight="menu" 
oCMenu.barClass="clBar"
oCMenu.barX="menu"
oCMenu.barY="menu"
oCMenu.barBorderX=0
oCMenu.barBorderY=0
oCMenu.barBorderClass=""

//Level properties - ALL properties have to be spesified in level 0
oCMenu.level[0]=new cm_makeLevel() //Add this for each new level
oCMenu.level[0].width=120
oCMenu.level[0].height=20 
oCMenu.level[0].regClass="clLevel0"
oCMenu.level[0].overClass="clLevel0over"
oCMenu.level[0].borderX=0
oCMenu.level[0].borderY=0
oCMenu.level[0].borderClass="clLevel0border"
oCMenu.level[0].offsetX=0 
oCMenu.level[0].offsetY=0
oCMenu.level[0].rows=0
//oCMenu.level[0].arrow=sRootFolder + "Images/main_menu.gif"
oCMenu.level[0].arrowWidth=10
oCMenu.level[0].arrowHeight=10
oCMenu.level[0].align="bottom"



//EXAMPLE SUB LEVEL[1] PROPERTIES - You have to specify the properties you want different from LEVEL[0] - If you want all items to look the same just remove this
oCMenu.level[1]=new cm_makeLevel() //Add this for each new level (adding one to the number)
oCMenu.level[1].width=190	//oCMenu.level[0].width
oCMenu.level[1].height=20
oCMenu.level[1].regClass="clLevel1"
oCMenu.level[1].overClass="clLevel1over"
oCMenu.level[1].borderX=1
oCMenu.level[1].borderY=1
//oCMenu.level[1].align="bottom" 
oCMenu.level[1].offsetX=-(oCMenu.level[0].width-2)/2+65
oCMenu.level[1].offsetY=0
oCMenu.level[1].borderClass="clLevel1border"
//oCMenu.level[1].arrow=sRootFolder + "Images/sub_menu.gif"
oCMenu.level[1].arrowWidth=8
oCMenu.level[1].arrowHeight=8



//EXAMPLE SUB LEVEL[2] PROPERTIES - You have to spesify the properties you want different from LEVEL[1] OR LEVEL[0] - If you want all items to look the same just remove this
oCMenu.level[2]=new cm_makeLevel() //Add this for each new level (adding one to the number)
oCMenu.level[2].width=oCMenu.level[0].width
oCMenu.level[2].height=20
oCMenu.level[2].offsetX=0
oCMenu.level[2].offsetY=0
oCMenu.level[2].regClass="clLevel1"
oCMenu.level[2].overClass="clLevel1over"
oCMenu.level[2].borderClass="clLevel1border"
//oCMenu.level[2].align="bottom" 

		oCMenu.makeMenu('top1','','Trang ch&#7911;','../Home.asp','',100,'','')

		oCMenu.makeMenu('top2','','B&#225;o c&#225;o tu&#7847;n','','','','')
		oCMenu.makeMenu('sub24','top2','&nbsp;&nbsp;&nbsp;Danh s&#225;ch B&#225;o c&#225;o','BCT_List.asp','','')
		oCMenu.makeMenu('sub25','top2','&nbsp;&nbsp;&nbsp;Nh&#7853;p m&#7899;i B&#225;o c&#225;o','BCT_New.asp','','');
		oCMenu.makeMenu('sub26','top2','&nbsp;&nbsp;&nbsp;Ph&#7909;c h&#7891;i B&#225;o c&#225;o','BCT_DeleteList.asp','','')
		oCMenu.makeMenu('sub27','top2','&nbsp;&nbsp;&nbsp;Ds B&#225;o c&#225;o ch&#7901; duy&#7879;t','BCT_choduyet.asp','','')

//		oCMenu.makeMenu('top3','','Administrator','','','','')		
//		oCMenu.makeMenu('top4','','&#272;&#7893;i m&#7853;t kh&#7849;u','','','','')
		oCMenu.makeMenu('top5','','Tho&#225;t','javascript:Thoat();','',100,'','')
		oCMenu.makeMenu('top6','','H&#432;&#7899;ng d&#7851;n s&#7917; d&#7909;ng','Help.asp','',180,'','')

function CreateSubMenu(nvalue){
	if (nvalue=='True'){
		oCMenu.makeMenu('sub23','top2','&nbsp;&nbsp;&nbsp;T&#236;m ki&#7871;m theo n&#7897;i dung file','BCT_AdvanceSearch.asp','','')
		oCMenu.makeMenu('sub28','top2','&nbsp;&nbsp;&nbsp;DS b&#225;o c&#225;o &#273;&#227; &#273;&#432;&#7907;c duy&#7879;t','BCT_DaDuyet.asp','','')
		oCMenu.makeMenu('sub29','top2','&nbsp;&nbsp;&nbsp;B&#225;o bi&#7875;u','BCT_rptBaoCao.asp','','')
	}
}

function AlwaysCall(){
	oCMenu.construct();
}


-->
