# Eau Claire's Salon

#### By _**Alex Shevlin and Frank Timmons**_ 

#### _A web app that allows a Dojo Manager to manage Martial Arts, Senseis, and Disciples._  

---

## Table of Contents

**[Technologies Used](#technologies-used)  
[Description](#description)  
[Technology Requirements](#technology-requirements)  
[Setup and Installation](#setupinstallation-requirements)  
[Known Bugs](#known-bugs)  
[License](#license)  
[Known Bugs](#known-bugs)**

---

## Technologies Used

* _C#_
* _.NET_
* _MVC_
* _HTML_
* _CSS_
* _REPL_
* _EntityFrameWork_
* _MySQL WorkBench_

## Description

_This is an MVC application to help a Dojo keep track of martial arts, senseis, and each sensei's disciples. Martial Arts can be added to the list that is taught at the Dojo. The Dojo Owner can see a list of martial arts, select them to see their details with a list of all senseis teaching that martial art. They can also see a list of senseis, select a sensei and see their details with a list of all disciples for that sensei._

_The relationship between Martial Arts and Sensei is one to many and Sensei to Disciple is many to many._

---
## Setup/Installation Requirements

<details>
<summary><strong>Install</strong></summary>
<ol>
<li>Install <a href="https://git-scm.com/download/">Git </a>and follow setup wizard
<li><a href="https://dotnet.microsoft.com/en-us/download/dotnet/5.0">Microsoft .NET SDK 5.0</a> and follow setup wizard
<li><a href="https://dev.mysql.com/downloads/workbench/">MySQL</a>, follow setup wizard, and create a localhost server on port 3306
<li>Clone this project and place files in a folder named `Dojo.Solution`
    <pre>Dojo.Solution
    └── Dojo</pre>
</ol>
</details>

<details>
<summary><strong>SQL Workbench Configuration</strong></summary>
<ol>
<li>Create an appsettings.json file in the "Dojo" directory of the project*  
   <pre>Dojo.Solution
   └── Dojo
    └── appsettings.json</pre>
<li> Insert the following code** : <br>

<pre>{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Port=3306;database=dojo;uid=root;pwd=[YOUR-PASSWORD-HERE];"
  }
}</pre>
<small>*note: you must include your password in the code block section labeled "YOUR-PASSWORD-HERE".</small><br>
<small>**note: if you plan to push this cloned project to a public-facing repository, remember to add the appsettings.json file to your .gitignore before doing so.</small>

<li>Once "appsettings.json" file has been created, open your git terminal.
<br><br>
How to Import a Database:
<ol> 
<li>In the Dojo.Solutions/Dojo folder run
  <li><strong>$ dotnet ef migrations add restoreDatabase</strong> in the console
  <li><strong>$ dotnet ef database update</strong> in the console
  <li>Open SQL Workbench.
  <li>Navigate to "dojo" schema.
  <li>Click the drop down, select "Tables" drop down.
  <li>Verify the tables, you should see <strong>disciple</strong>, <strong>disciplesensei</strong>, <strong>martialart</strong>, &<strong> sensei</strong>.
</details>

<details>
<summary><strong>To Run</strong></summary>
Navigate to  
   <pre>Dojo.Solution
   └── <strong>Dojo</strong></pre>
<ol>
  <li>Run <strong>$ dotnet restore</strong> in the console
  <li>Run <strong>$ dotnet run</strong> in the console
</details>
<br>

This program was built using *`Microsoft .NET SDK 5.0.401`*, and may not be compatible with other versions. Your milage may vary.

---
## Known Bugs

* _No known bugs_

## License

[GNU](/LICENSE-GNU)

Copyright (c) 2022 Alex Shevlin && Frank Timmons