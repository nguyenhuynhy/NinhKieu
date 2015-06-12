<%@ Register TagPrefix="FTB" Namespace="FreeTextBoxControls" Assembly="FreeTextBox" %>
<%@ Page Language="C#" ValidateRequest=false Trace="false" %>
<HTML>
	<HEAD>
		<title>Image Gallery</title>
		<script runat="server">
protected void Page_Load(Object Src, EventArgs E) {
	
	// *** remove this return statement to use the following code ***
	ImageGallery1.JavaScriptLocation = FreeTextBoxControls.ResourceLocation.ExternalFile;
	ImageGallery1.UtilityImagesLocation = FreeTextBoxControls.ResourceLocation.ExternalFile;
	ImageGallery1.ThumbnailHeight = 70;
    ImageGallery1.ThumbnailWidth = 60;
    ImageGallery1.SupportFolder = "~/Inc/FreeTextBox/";
	return;

	string currentFolder = ImageGallery1.CurrentImagesFolder;
	
	// modify the directories allowed
	if (currentFolder == "~/images") {

		// these are the default directories FTB:ImageGallery will find
		string[] defaultDirectories = System.IO.Directory.GetDirectories(Server.MapPath(currentFolder),"*");
		
		// user defined custom directories
		string[] customDirectories = new string[] {"folder1","folder2"};
		
		// the gallery will use these images in this instance
		ImageGallery1.CurrentDirectories = customDirectories;
	}
	
	
	// modify the images allowed
	if (currentFolder == "~/images") {

		System.IO.DirectoryInfo directoryInfo = new System.IO.DirectoryInfo(Server.MapPath(currentFolder));

		// these are the default images FTB:ImageGallery will find
		System.IO.FileInfo[] defaultImages = directoryInfo.GetFiles("*");
		
		// user defined custom images (here, we're just allowing the first two)
		System.IO.FileInfo[] customImages = new System.IO.FileInfo[2] {defaultImages[0], defaultImages[1]};
		
		// the gallery will use these images in this instance
		ImageGallery1.CurrentImages = customImages;
	}	
	
}
		</script>
	</HEAD>
	<body>
		<table width="100%">
			<tr>
				<td>
					<form id="Form1" runat="server" enctype="multipart/form-data">
						<div id="divGallery" style="width:600;height:500;overflow:auto;">
							<FTB:ImageGallery AllowImageDelete="true" AllowImageUpload="true" AllowDirectoryCreate="true" AllowDirectoryDelete="true"
								id="ImageGallery1" runat="Server" />
						</div>
					</form>
				</td>
			</tr>
		</table>
	</body>
</HTML>
