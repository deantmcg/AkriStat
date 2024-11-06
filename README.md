# AkriStat - Football Scouting Platform

AkriStat is a platform for football scouting, created as a final-year Software Engineering project at the University of Ulster. It allows scouts and analysts to evaluate players in Europe’s "Top 5" leagues for the 2019-20 season. Player data is sourced from [FBref](https://fbref.com/).

## Overview

AkriStat provides a range of scouting tools, including player profiles, team analysis, and custom scouting reports. Users can register as either standard users or as scouts/analysts affiliated with specific teams.

## Features

- **Player Profiles**: View a dashboard detailing performance for individual players.
- **Team Profiles**: View a dashboard detailing performance for individual teams.
- **Quick Search**: Search for players by their name.
- **Advanced Search**: Find players who fit a specific criteria e.g. Transfer Value, Goals Scored etc.
- **Shortlists**: Create shortlists the keep track of players you are interested in.
- **Statistics Comparison**: Compare 2-6 players and see how they stack up against each other in each metric.
- **League Tables**: View current standings for each league.
- **Viz**: Use any metric we have stored to generate one of the following Visualisations:
    - Line Graph
    - Bar Chart
    - Column Chart
    - Pie Chart
    - Scatter Plot
    - Radar Chart"

## User Roles

- **Standard Users**: Access to all analysis tools.
- **Scouts/Analysts**: Assigned to teams, performing analysis on a professional basis.
- **Chief Scouts**: Assigned to teams, able to perform their own analysis and monitor their Scouts' and Analysts' work.
- **Admin**: Manage user permissions and edit information stored on players and teams.

## Technologies Used

- **ASP.NET Core MVC** for framework
- **Entity Framework Core** for data management
- **SQL Server** for the database
- **HTML, CSS, JavaScript, jQuery** for frontend design
