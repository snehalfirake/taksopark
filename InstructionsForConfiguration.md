<h1><p align='center'>Instructions to Configure Local Environment</p></h1>
<br>
<h3><p align='center'>Get Source Code</p></h3><br>
<ol>
<li>Install TortoiseSVN(from <a href='http://sourceforge.net/projects/tortoisesvn/'>http://sourceforge.net/projects/tortoisesvn/</a>)</li>
<li>Create folder in local hard disk(for example "Taksopark")</li>
<li>Pull the last version of the project from <a href='https://taksopark.googlecode.com/svn/trunk/'>https://taksopark.googlecode.com/svn/trunk/</a> into the created folder</li>
</ol>
<p></p>
<h3><p align='center'>Deploy the Database</p></h3><br>
<p></p>
P.S. You don't need to deploy the database localy on your PC as it's already located on the server side and appropriate connection strings are put in the Web.config files.<br>
</br>But if you still want to deploy it - use the below instructions:<br>
<ol>
<li>Install SQL Server Express 2012/2014</li>
<li>Install Microsoft SQL Server and SQL Management Studio 2012/2014</li>
<li>To configure the database use one of the following options:<br>
<ul>
<li>Execute the script <a href='https://taksopark.googlecode.com/svn/trunk/DBFiles/CreateLocalDB.zip'>https://taksopark.googlecode.com/svn/trunk/DBFiles/CreateLocalDB.zip</a></li>
<li>Use backup file (made from MS SQL Server 2012) <a href='https://taksopark.googlecode.com/svn/trunk/DBFiles/TaxiServiseDB.bak'>https://taksopark.googlecode.com/svn/trunk/DBFiles/TaxiServiseDB.bak</a></li>
</ul>
</li>
</ol>
<h3><p align='center'>Run the System</p></h3><br>
<p></p>
<ol>
<li>Install Microsoft Visual Studio 2012/2013(Express for Web is enought)</li>
<li>Open the solution Taksopark.sln</li>
<li>Change connection string in the Web.config of the project "Taksopark.MVC"</li>
<li>Change connection string in the Web.config of the project "Taksopark.WebForms"</li>
<li>The projects "Taksopark.MVC" and "Taksopark.WebForms" are ready to run</li>
</ol>