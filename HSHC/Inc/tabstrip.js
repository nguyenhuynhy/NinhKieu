//Modified by Vien Hoang Tuan Anh


var divs = document.body.all.tags("DIV");
var tagA = document.body.all.tags("A");
/*
if (divs.length > 1)
{
    for (i=2; i < divs.length; i++) 
        if (divs(i).className == 'eDMS_tabPanel')
            divs(i).style.display = 'none';
}           
*/
function showPanel(id, obj) {

    // Show the Panel (and hide the rest)
    //var divs = document.body.all.tags("DIV");

    for (i=0; i < divs.length; i++) { 
    if (divs(i).className == 'eDMS_tabPanel') {
        if (divs(i).id == id)
        {
            divs(i).style.display = 'block';
            document.body.all("hPanelID").value = id;
        }
        else
            divs(i).style.display = 'none';
        }
    }
		
	for (i=0; i < tagA.length; i++)
		if (tagA(i).className == 'eDMS_tabSelected')
			tagA(i).className = 'eDMS_tab';
	
	document.all.namedItem(obj).className = 'eDMS_tabSelected';
	
}

