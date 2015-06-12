<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
	<xsl:output method="xml" version="1.0" encoding="UTF-8" indent="yes"/>
	<xsl:param name="LogFileName"/>
	<xsl:param name="PortalID"/>
	<xsl:template match="/">
		<table width="100%" bordercolor="#CCCCCC" CELLSPACING="0" CELLPADDING="1" BORDER="1">
			<tbody>
				<tr>
					<th colspan="2" align="center">Time</th>
					<th>Portal</th>
					<th>User</th>
					<th>Tab</th>
					<th>Exception</th>
				</tr>
				<xsl:for-each select="exceptions/ExceptionInformation[Exception/@PortalID=$PortalID or $PortalID='-1']">
				     <xsl:call-template name="Exception"/>
				</xsl:for-each>
				
			</tbody>
		</table>	
	</xsl:template>

	<xsl:template name="Exception">
		<tr>
		       <td class="Normal">
		    		<input type="checkbox" name="Exception"><xsl:attribute name="value"><xsl:value-of select="position()"/>|<xsl:value-of select="$LogFileName"/></xsl:attribute><xsl:attribute name="onclick">flipFlop('exc<xsl:value-of select="position()"/>','#C0C0C0')</xsl:attribute></input>
		    	</td>
			<td class="Normal">
				<xsl:value-of select="AdditionalInformationProperty/@ExceptionManager.TimeStamp"/>
			</td>
			<td align="right" class="Normal">
				<xsl:value-of select="Exception/@PortalID"/><xsl:value-of select="concat('&amp;', 'nbsp;')" disable-output-escaping="yes" />
			</td>
			<td align="right" class="Normal">
				<xsl:value-of select="Exception/@UserID"/><xsl:value-of select="concat('&amp;', 'nbsp;')" disable-output-escaping="yes" />
			</td>
			<td align="left" class="Normal">
				<xsl:if test="Exception/@ActiveTabID!=''">
					TabID: <xsl:value-of select="Exception/@ActiveTabID"/><xsl:if test="Exception/@ActiveTabName!=''"><br/>Tab Name: <xsl:value-of select="concat('&amp;', 'nbsp;')" disable-output-escaping="yes" /><xsl:value-of select="Exception/@ActiveTabName"/></xsl:if>
				</xsl:if><xsl:value-of select="concat('&amp;', 'nbsp;')" disable-output-escaping="yes" />
			</td>
			<td class="Normal">
				<table border="0" cellspacing="0" cellpadding="0" width="100%">
					<tbody>
						<tr>
							<th class="Normal" align="left"><xsl:value-of select="Exception/@ExceptionType"/></th>
							<th class="Normal" align="right"><font style="font-weight:bold"><xsl:value-of select="Exception/Exception/@ExceptionType"/></font></th>
						</tr>
					</tbody>
				</table>
				<font style="color:#800000;font-weight:bold"><xsl:value-of select="Exception/Exception/@Message"/></font>
			</td>
		</tr>
		<tr>
			<td colspan="6" class="Normal">	<div style="display: none;"><xsl:attribute name="id">exc<xsl:value-of select="position()"/></xsl:attribute>
				<xsl:if test="Exception/@FriendlyName !=''">
					<b>Module Name:</b>
					<xsl:value-of select="concat('&amp;', 'nbsp;')" disable-output-escaping="yes" />
					<xsl:value-of select="concat('&amp;', 'nbsp;')" disable-output-escaping="yes" />
					<xsl:value-of select="Exception/@FriendlyName"/><br/> 
				</xsl:if>
				<xsl:if test="Exception/@FileName !=''">
					<b>File Name:</b>
					<xsl:value-of select="concat('&amp;', 'nbsp;')" disable-output-escaping="yes" />
					<xsl:value-of select="concat('&amp;', 'nbsp;')" disable-output-escaping="yes" />
					<xsl:value-of select="Exception/@FileName"/><br/> 
				</xsl:if>
				<xsl:if test="Exception/@FileLineNumber !=''">
					<b>Line Number:</b>
					<xsl:value-of select="concat('&amp;', 'nbsp;')" disable-output-escaping="yes" />
					<xsl:value-of select="concat('&amp;', 'nbsp;')" disable-output-escaping="yes" />
					<xsl:value-of select="Exception/@FileLineNumber"/><br/> 
				</xsl:if>
				<xsl:if test="Exception/@FileColumnNumber !=''">
					<b>Column Number:</b>
					<xsl:value-of select="concat('&amp;', 'nbsp;')" disable-output-escaping="yes" />
					<xsl:value-of select="concat('&amp;', 'nbsp;')" disable-output-escaping="yes" />
					<xsl:value-of select="Exception/@FileColumnNumber"/><br/> 
				</xsl:if>
				<xsl:if test="Exception/@Method !=''">
					<b>Method:</b>
					<xsl:value-of select="concat('&amp;', 'nbsp;')" disable-output-escaping="yes" />
					<xsl:value-of select="concat('&amp;', 'nbsp;')" disable-output-escaping="yes" />
					<xsl:value-of select="Exception/@Method"/><br/> 
				</xsl:if>
				<xsl:if test="Exception/@PortalID !=''">
					<b>Portal ID:</b>
					<xsl:value-of select="concat('&amp;', 'nbsp;')" disable-output-escaping="yes" />
					<xsl:value-of select="concat('&amp;', 'nbsp;')" disable-output-escaping="yes" />
					<xsl:value-of select="Exception/@PortalID"/><br/> 
				</xsl:if>
				<xsl:if test="Exception/@UserID !=''">
					<b>User ID:</b>
					<xsl:value-of select="concat('&amp;', 'nbsp;')" disable-output-escaping="yes" />
					<xsl:value-of select="concat('&amp;', 'nbsp;')" disable-output-escaping="yes" />
					<xsl:value-of select="Exception/@UserID"/><br/> 
				</xsl:if>
				<xsl:if test="Exception/@ActiveTabName !=''">
					<b>Tab Name:</b>
					<xsl:value-of select="concat('&amp;', 'nbsp;')" disable-output-escaping="yes" />
					<xsl:value-of select="concat('&amp;', 'nbsp;')" disable-output-escaping="yes" />
					<xsl:value-of select="Exception/@ActiveTabName"/><br/> 
				</xsl:if>
				<xsl:if test="Exception/@ModuleID!=''">
					<b>Module ID:</b>
					<xsl:value-of select="concat('&amp;', 'nbsp;')" disable-output-escaping="yes" />
					<xsl:value-of select="concat('&amp;', 'nbsp;')" disable-output-escaping="yes" />
					<xsl:value-of select="Exception/@ModuleID"/><br/>
				</xsl:if>
				<xsl:if test="Exception/@ModuleControlSource!=''">
					<b>Module Control Source:</b>
					<xsl:value-of select="concat('&amp;', 'nbsp;')" disable-output-escaping="yes" />
					<xsl:value-of select="concat('&amp;', 'nbsp;')" disable-output-escaping="yes" />
					<xsl:value-of select="Exception/@ModuleControlSource"/><br/>
				</xsl:if>
				<xsl:if test="Exception/@DatabaseVersion!=''">
					<b>Database Version:</b>
					<xsl:value-of select="concat('&amp;', 'nbsp;')" disable-output-escaping="yes" />
					<xsl:value-of select="concat('&amp;', 'nbsp;')" disable-output-escaping="yes" />
					<xsl:value-of select="Exception/@DatabaseVersion"/><br/>
				</xsl:if>
				<xsl:if test="Exception/@DatabaseVersion!=''">
					<b>Windows Identity Name:</b>
					<xsl:value-of select="concat('&amp;', 'nbsp;')" disable-output-escaping="yes" />
					<xsl:value-of select="concat('&amp;', 'nbsp;')" disable-output-escaping="yes" />
					<xsl:value-of select="Exception/@WindowsIdentityName"/><br/>
				</xsl:if>
				<xsl:if test="Exception/Exception/StackTrace!=''">
					<b>Stack Trace:</b><xsl:value-of select="concat('&amp;', 'nbsp;')" disable-output-escaping="yes" /><xsl:value-of select="concat('&amp;', 'nbsp;')" disable-output-escaping="yes" /><xsl:value-of select="Exception/Exception/StackTrace"/><br/>
				</xsl:if>
                <b>Additional Info:</b><xsl:value-of select="concat('&amp;', 'nbsp;')" disable-output-escaping="yes" /><xsl:value-of select="concat('&amp;', 'nbsp;')" disable-output-escaping="yes" />
                <xsl:apply-templates select="AdditionalInformationProperty"/><br/>
				
				<xsl:value-of select="concat('&amp;', 'nbsp;')" disable-output-escaping="yes" />
				</div></td>
		</tr>
	</xsl:template>
	<xsl:template match="AdditionalInformationProperty">
	    <xsl:value-of select="."/>
	</xsl:template>
</xsl:stylesheet>
