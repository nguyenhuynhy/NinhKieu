/*
Modified by Viên HoaÌng Tuâìn Anh
*/

function addItem(listID) {
    // Get the list boxes
    var srcList = document.getElementById(listID + '_SrcList');
    var dstList = document.getElementById(listID + '_DstList');
    var selectedStateField = document.getElementById(listID + '_SelectedState');
    var selectedStateField2 = document.getElementById(listID + '_SelectedState2');
    var allStateField = document.getElementById(listID + '_AllState');
    var allStateField2 = document.getElementById(listID + '_AllState2');
	
	
    // return when no option selected
    if (srcList.selectedIndex == -1)
        return;

    // Move the option

    for (var i=srcList.length - 1; i >= 0; i--){
		if (srcList.options(i).selected){
			//alert(srcList.options(i).text);
	
			//var srcOption = srcList.options(srcList.options.selectedIndex)
			var srcOption = srcList.options(i)
			var dstOption = document.createElement("OPTION");
		    
			dstList.options.add(dstOption);
			dstOption.innerText = srcOption.text;
			dstOption.value = srcOption.value;
			//srcList.remove(srcList.options.selectedIndex);
			srcList.remove(i);

			// Record in SelectedState hidden field
			if (selectedStateField.value == ''){
				selectedStateField.value = dstOption.innerText; 
				selectedStateField2.value = dstOption.value; 
			}else{
				selectedStateField.value = selectedStateField.value + ',' + dstOption.innerText;
				selectedStateField2.value = selectedStateField2.value + ',' + dstOption.value;
			}
			// Remove from AllState hidden field
			searchAndRemove(allStateField, dstOption.innerText);
			searchAndRemove(allStateField2, dstOption.value);
		
		}
	}
}


function removeItem(listID) {
    // Get the list boxes
    var srcList = document.getElementById(listID + '_DstList');
    var dstList = document.getElementById(listID + '_SrcList');
    var selectedStateField = document.getElementById(listID + '_SelectedState');
    var selectedStateField2 = document.getElementById(listID + '_SelectedState2');
    var allStateField = document.getElementById(listID + '_AllState');
    var allStateField2 = document.getElementById(listID + '_AllState2');

    // return when no option selected
    if (srcList.selectedIndex == -1)
        return;

	for (var i=srcList.length - 1; i >= 0; i--){
		if (srcList.options(i).selected){
			//alert(srcList.options(i).text);
	
			// Move the option
			//var srcOption = srcList.options(srcList.options.selectedIndex)
			var srcOption = srcList.options(i)
			var dstOption = document.createElement("OPTION");
			dstList.options.add(dstOption);
			dstOption.innerText = srcOption.text;
			dstOption.value = srcOption.value;
			//srcList.remove(srcList.options.selectedIndex);
			srcList.remove(i);

			// Record in AllState hidden field
			if (allStateField.value == ''){
				allStateField.value = dstOption.innerText; 
				allStateField2.value = dstOption.value;
			}else{
				allStateField.value = allStateField.value + ',' + dstOption.innerText;
				allStateField2.value = allStateField2.value + ',' + dstOption.value;
			}

			// Remove from SelectedState hidden field
			searchAndRemove(selectedStateField, dstOption.innerText);  
			searchAndRemove(selectedStateField2, dstOption.value);  
		
		}
	}   
}


function searchAndRemove(stateField, item) {
    var newStateValue = '';
    var counter = 0;

    fields = stateField.value.split(',');
    for (i=0; i< fields.length; i++) {
        if (fields[i] != item) {
            counter ++;
            if (counter>1)
                newStateValue = newStateValue + ',' + fields[i];
            else
                newStateValue = fields[i];
        }
   }

    stateField.value = newStateValue;
}


