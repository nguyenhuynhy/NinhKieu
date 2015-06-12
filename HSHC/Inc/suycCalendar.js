
/****************************************************************************
_____________________________________________________________________________  
        
        Class:      suycCalendar
        Version:  1.1
        Created: 18-Jul-2001
        Author:  Darren Neimke
        Email:    darren@showusyourcode.com
        URL:      http://www.showusyourcode.com/
_____________________________________________________________________________        
        
        Constructor:
        -----------------
        var objCalendar = new suycCalendar([month(Int)], [year(Int)])
        ________________________________________________________________________
        
        Method Selectors:
        -------------------------
        BuildCalendar           - Renders a new calendar with a default of current month.
        goToCurrent             - Renders the calendar to the current month.
        toggleCalendar ( int )  - int = number of months to toggle by.
        show                     - sets the visibility of the Canvass to visible
        hide                      - sets the visibility of the Canvass to not visible
        moveTo                 - accepts x,y as pixels moves the canvass to that position
        bindToElement           - Not yet implemented.
        
        Properties Exposed:
        ---------------------------
        hasEvents   (type: Boolean) - if true then interface raises events.
        posX          allows the user to set the left location (the number of pixels from the left edge of the browser window). 
        posY          allows the user to set the top location (the number of pixels from the top edge of the browser window). 
        
        Notes:
        ---------
        If hasEvents is set to True then you need to implement the following event handlers:
            - clickhandler (d,m,y)   - receives the event thrown by the user clicking on a day/date
            - toggleCalendar (i)      - receives the event thrown by the user clicking on << or >>
            - toggleCurrent ()        - receives the event thrown by the user clicking on [ Today ]
            
        Calendar also exposes the following CSS classes:
            - clickable               : refers to the <<, [ TODAY ], and >> navigation controls at the base of the calendar
            - calendar_normal    : the normal state of a calendar date 
            - calendar_clickable  : the onMouseOver state of a calendar date
            - TR.monthsheader  : the row that contains the abbreviated Day names near the top of the calendar
            - TD.monthsheader : the individual cells contained by the aforementioned row
            
        Enjoy!!

*****************************************************************************/



/****************************************************************************
        BEGINNING OF CLASS
*****************************************************************************/
function suycCalendar(m,y)
{
    
    if (typeof(_calendar_prototype_called) == 'undefined')
    {
        _calendar_prototype_called = true ;
        
        // Object methods
        this.BuildCalendar = _create ;
        this.createCanvass = _createCanvass ;
        this.showCalendar = _showCalendar ;
        this.goToCurrent = _goToCurrent ;
        this.toggleCalendar = _toggleCalendar ;
        this.moveTo = _positionCanvass ;
        this.hide = _hide ;
        this.show = _show ;
        this.init = _init ;
    }
    
        // Object properties
        this.name = 'default' ;
        this.rowBGColor = 'palegoldenrod' ;
        this.currentDay = 0 ;
        this.currentMonth = 0 ;
        this.currentYear = 0 ;
        this.visible = false ;
        this.posX = 10 ;
        this.posY = 10 ;
        this.isIE4 = '';
        this.isNav4 = '' ;
        
        // If you set hasEvents fo FALSE then the calendar face is dumbed out.
        this.hasEvents = true ;
        
        this.canvass = '' ; // The DIV || LAYER that we display the calendar on.
        this.bindToElement = '' ;  // Bind to an ELEMENT on the page.
    
    // Array of day names
    this.days = new Array("C.N", "T.2", "T.3", "T.4","T.5", 
                                   "T.6", "T.7");
    // Array of month names
    this.months = new Array("Th&#225;ng 1", "Th&#225;ng 2", "Th&#225;ng 3", "Th&#225;ng 4", "Th&#225;ng 5","Th&#225;ng 6", "Th&#225;ng 7", 
                                        "Th&#225;ng 8", "Th&#225;ng 9", "Th&#225;ng 10", "Th&#225;ng 11", "Th&#225;ng 12");
    // Array of total days in each month
    this.totalDays = new Array(31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31);
    
    // Call the Initialize() event.
    this.init(m,y) ;
}

function _show()
// This function displays the objects canvass.
{
    if(this.isNav4)
    {
        this.canvass.visibility = 'show' ;
        this.canvass.left = this.posX ;
        this.canvass.top = this.posY ;   
    } else {
        this.canvass.style.visibility = 'visible' ;
        this.canvass.style.left = this.posX ;
        this.canvass.style.top = this.posY ;
    }
    
    
    this.visible = true ; 
}

function _hide()
// This function hides the objects canvass.
{
    if(this.isNav4)
    {
        this.canvass.visibility = 'hide' ;   
    } else {
        this.canvass.style.visibility = 'hidden' ;
    }
    this.visible = false ;
}

function _init(m,y)
{
    if (parseInt(navigator.appVersion.charAt(0)) >= 4)
    // Browser check.
    {
        this.isNav4 = (navigator.appName == "Netscape") ? true : false ;
        this.isIE4 = (navigator.appName.indexOf("Microsoft") != -1) ? true : false ;
    }
    
    // Populate the current Day|Month|Year properties
    var obj = new Date();
    this.currentDay = obj.getDate();
    this.currentMonth = obj.getMonth() + 1;
    this.currentYear = (obj.getYear() < 1000) ? obj.getYear() + 1900 : obj.getYear();
    
    /* 
        The constructor optionally accepts m && y parameters
        if none are supplied, the calendar defaults to the current
        month 
    */
    this.month = m || this.currentMonth ;
    this.year = y || this.currentYear ;
    
    // Create the canvass that we will be displaying the calendar on
    this.createCanvass() ;
    obj = null ;
  
}

function _createCanvass()
{
    
    // Create canvass for NN4+
    if (this.isNav4) 
    { 
        this.canvass = new Layer(200) ;
        this.canvass.left = this.posX ;
        this.canvass.top = this.posY ;
    }
    
    // Create canvass for IE4+
    if (this.isIE4)
    { 
        var objDiv = document.createElement("<DIV STYLE='position: absolute'>") ;
        document.body.appendChild (objDiv) ;
        this.canvass = objDiv ;
        this.canvass.style.left = this.posX ;
        this.canvass.style.top = this.posY ;
    }
}

function _positionCanvass(x,y)
{
    // if either x || y were not supplied, default to the current settings.
    if(x==null || y==null) { x=this.posX; y=this.posY ; return ;}
    
    if( isNaN(x) || isNaN(y) )
    {
        alert('You can only enter numbers for the x/y co-ordinates') ;
        return ;
    }
    
    // apply the new settings for NN
    if (this.isNav4) 
    { 
        this.canvass.left = this.posX = x ;
        this.canvass.top = this.posY = y ;
    }
    
    // apply the new settings for NN
    if (this.isIE4)
    { 
        this.canvass.style.left = this.posX = x ;
        this.canvass.style.top = this.posY = y ;
    }
    
}

function _goToCurrent()
{
    
    this.year = this.currentYear ;
    this.month = this.currentMonth ;
   this.day= this.currentDay;
    this.BuildCalendar() ;
}

function _toggleCalendar(n)
{
    var currentMonth = this.month ;
    var currentYear = this.year ;
    
    if((currentMonth + n) == 0)
    { 
        this.year = currentYear-1 ; 
        this.month = 12 ; 
    }
    else if((currentMonth + n) == 13)
    { 
        this.year = currentYear+1 ; 
        this.month = 1 ; 
    }
    else
    {
        this.month = currentMonth + n ;
    }
    this.BuildCalendar() ;
}

// Create and Display Calendar.
function _create()
{
    // Counters to count rows and days, String to store calendar output.
    var rowCount = 0 ;
    var numRows = 0 ;
    var sOut = new String() ;
    
    // Leap year correction
    if (this.year % 4 == 0 && (this.year % 100 != 0 || this.year % 400 == 0)) {
    	this.totalDays[1] = 29 ;
    }
    
    var obj = new Date(this.year, this.month-1, 1) ;
    this.firstDayOfMonth = obj.getDay() ;
    obj.setDate(31) ;
    this.lastDayOfMonth = obj.getDay() ;
    obj = null ;
    
    sOut = "<table style=\"FONT-FAMILY:Arial\" border=1 cellpadding=1 cellspacing=1 class=calCalendar bgcolor=#b6cbeb>" ;
    /*  Write the TABLE header (month/year) */
    sOut += "<tr CLASS='calTitleBar'><td colspan=6 align=left><span style=\"font-size: 'x-smaller';\">&nbsp;<b>" + this.months[this.month-1] + " " + this.year + "</b></span></td>" ;
    sOut += "<td ALIGN='right'><A HREF=\"javascript:  ;\"  onClick='calClose() ; return false ;' TITLE='Close'><img src='img/x.gif' border='0'></A></td>" ;
    sOut += "</tr>" ;

    /*  Write the abbreviated day names */
    sOut += "<tr class='calMonthsheader'>" ;
    for (x=0; x<7; x++) {
        sOut += "<td class='calMonthsheader'><span style='font-size: smaller'>" + this.days[x].substring(0,3) + "</span></td>" ;
    }
    sOut += "</tr>" ;

    /* Start of BODY */
    sOut += "<tr  class='bodyMain'>" ;
    numRows++ ;
    
    for (x=1; x<=this.firstDayOfMonth; x++) {
        /* pad the blank days at the beginning of the month. */
        rowCount++;
        sOut += "<td>&nbsp;</span></td>" ;
    }
    
    
    /* Increment the current date */
    this.dayCount=1;
    while (this.dayCount <= this.totalDays[this.month-1]){
    	/* Display new row after each 7 day block.  */
    	if (rowCount % 7 == 0)
    	{
    	    sOut += "</tr>\n<tr  class='bodyMain'>" ;
    	    numRows++ ;
    	}

         /* Insert the Date. */
        if (this.dayCount==this.currentDay && this.month==this.currentMonth && this.year==this.currentYear)
        {
        sOut += "<td style=\"Font-size:10pt\" align=center bgcolor=#dddddd CLASS='calClickable' onMouseOver=\"this.className = 'calClickable_hover';\" onMouseOut=\"this.className = 'calClickable';\"><A HREF=\"javascript:  ;\" style=\"TEXT-decoration:none\""

        if (this.hasEvents) sOut += " onClick='clickhandler(" + this.dayCount + "," + this.month + "," + this.year + ") ;'" ;

        sOut += " CLASS='calClickable'>" +"<FONT color=#2d997c><B>"+ this.dayCount +"</B></FONT>"+ "</A>"  
        sOut += "</td>" ;
        
        }
        else
        {
        sOut += "<td style=\"Font-size:10pt\" align=center CLASS='calClickable' onMouseOver=\"this.className = 'calClickable_hover';\" onMouseOut=\"this.className = 'calClickable';\"><A HREF=\"javascript:  ;\" style=\"TEXT-decoration:none\""

        if (this.hasEvents) sOut += " onClick='clickhandler(" + this.dayCount + "," + this.month + "," + this.year + ") ;'" ;

        sOut += " CLASS='calClickable'>" + this.dayCount + "</A>"  
        sOut += "</td>" ;
        }
        this.dayCount++ ;
        rowCount++ ;
    }

    while (rowCount % 7 != 0) {
        /* pad the blank days at the end of the month. */
        rowCount++ ;
        sOut += "<td><span style='font-size: smaller'>&nbsp;</span></td>" ;
    }
    sOut += "</tr>" ;
    // End of BODY
    
    // Write the Calendar Navigator.
    if(this.hasEvents) {
        sOut += "<tr>" ;
        sOut += "<td colspan=2 align=left>" ;
        sOut += "<A HREF=\"javascript:  ;\"  style=\"TEXT-decoration:none\" onClick='toggleCalendar(-1) ; return false ;' CLASS='calClickable'  onMouseOver=\"this.className = 'calClickable_hover';\" onMouseOut=\"this.className = 'calClickable';\" TITLE='Th&#225;ng tr&#432;&#7899;c' />&lt;&lt;</A>" ;
        sOut += "</td>" ;
        sOut += "<td colspan=3 align=center>" ;
        sOut += "<A HREF=\"javascript:  ;\"  style=\"TEXT-decoration:none\" onClick='toggleCurrent() ; return false ;' CLASS='calClickable'  onMouseOver=\"this.className = 'calClickable_hover';\" onMouseOut=\"this.className = 'calClickable';\" TITLE='Th&#225;ng n&#224;y' />[H&#244;m nay]</A>" ;
        sOut += "</td>" ;
        sOut += "<td colspan=2 align=right>" ;
        sOut += "<A HREF=\"javascript:  ;\"  style=\"TEXT-decoration:none\" onClick='toggleCalendar(1) ; return false ;' CLASS='calClickable'  onMouseOver=\"this.className = 'calClickable_hover';\" onMouseOut=\"this.className = 'calClickable';\" TITLE='Th&#225;ng t&#7899;i' />&gt;&gt;</A>" ;
        sOut += "</td>" ;
        sOut += "</tr>" ;
    }
    
    sOut += "</table>" ;
    
    // Render the calendar
    this.showCalendar (sOut) ;
}

function _showCalendar (s)
{
    if(this.isNav4)
    {
        this.canvass.document.open() ;
        this.canvass.document.writeln(s) ;
        this.canvass.document.close() ;
    } else {
        this.canvass.innerHTML = s ;
    }
    this.show() ;
}

/****************************************************************************
        END OF CLASS
*****************************************************************************/