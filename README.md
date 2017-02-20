# Asp.NETWebForms Application

# SalaryCalculator

[![Build status](https://ci.appveyor.com/api/projects/status/se8cihlsdj00miix/branch/master?svg=true)](https://ci.appveyor.com/project/alexnestorov/asp-netwebformsapp/branch/master)
[![Coverage Status](https://coveralls.io/repos/github/Team-Ressurrection/ASP.NETWebFormsApp/badge.svg?branch=master)](https://coveralls.io/github/Team-Ressurrection/ASP.NETWebFormsApp?branch=master)

<p align="center">
<a href="http://academy.telerik.com/">
<img src="https://camo.githubusercontent.com/08ecbe7b67d65cc7c6990787e2836b27b4296f2d/68747470733a2f2f7261772e6769746875622e636f6d2f666c65787472792f54656c6572696b2d41636164656d792f6d61737465722f50726f6772616d6d696e6725323077697468253230432532332f436f6465732f4f746865722f54656c6572696b2e706e67"/>
</a>

###:mortar_board:Team Members
| Name              | Academy Username      	|
|-------------------|-------------------|
|                   | :white_check_mark:|
|Александър Несторов |__Alexander.N__	        |

## Project Description  

This is a simple online salary calculator that allows people to calculate their net wage, social security income, income tax and personal insurance taxes according to latest legislation changes in Labour Code. The calculator allows you to register as a company and create labor and non-labor contracts for employees and also view reports for them.

You can view the youtube video here:

## Usage

#### Basic usage
  1. Registered users can create payroll documents such as: 
    - Employee paychecks
    - Remuneration Bills
    - or can calculate personal insurance of selfemployment people.
  2. Automatic calculation for each person:
    - social security income
    - income tax
    - net wage
  3. Could view reports for all documents of their employees:
    - All Labor contracts
    - All Non-Labor contracts
    - All personal insurance information for selfemployment people

#### Registration
You can register at our website in Register menu.
Required fields for registration.
  - E-Mail: aaa@aaa.com
  - Company Name: Demo Company
  - Company Address: bul. ......

## Application public part

Everyone can see information:
  - home page: current legislation changes
  - about page: owner information
  - contact page: owner coordinates

## Application private part

#### Admin
Users with role "admin" can edit or/and delete information in settings menu.
  - Paychecks
  - Remuneration bills
  - Users
  - Employees
  - Selfemployment people
  
#### User
Users with role "user" can create, view their own documents.
  - Labor contracts
  - Non-Labor contracts
  - Selfemployment personal insurance information

## Backend server

MSSQL server.

## Database

MSSQL.

## FAQ

## Project TODOs:
  - Implement calculation with part time job, paid leave and absence
  - Detail information about personal insurance (depends on birth year before 01.01.1960 and after 31.12.1959)
  - Users to edit or/and delete their own documents
