![GitHub Release](https://img.shields.io/github/v/release/eskhas/library-automation-project?color=%2000ff00)

# Library Automation Project

The purpose of this project is to help library personnel to loan books to the people.

### Latest Update

- People can loan books
- Some verifying for deletion

### Some Screenshots of the Application

Home Page

![image](https://github.com/user-attachments/assets/427bc755-44e5-47b6-a829-8d173163dcac)

Books Page

![image](https://github.com/user-attachments/assets/3fb77aaa-e842-4f28-ac62-34377fa7182d)

<div align="center">
  <table>
    <tr>
      <td align="center">Editing a book</td>
      <td align="center">Creating a new author</td>
      <td align="center">Deleting a member</td>
      <td align="center">Details of a Book</td>
    </tr>
    <tr>
      <td><img src="https://github.com/user-attachments/assets/1adf7d3c-295d-47aa-af7e-e8700e3ced68" width="200" /></td>
      <td><img src="https://github.com/user-attachments/assets/a4b1bd01-06c3-4bf0-b947-016589196ef7" width="200" /></td>
      <td><img src="https://github.com/user-attachments/assets/64332fad-d3e3-481e-a45c-0c53e756b30c" width="200" /></td>
      <td><img src="https://github.com/user-attachments/assets/70ca55b9-d2a2-4a92-a092-bc41e68aefec" width="200" /></td>
    </tr>
  </table>
</div>

### To Run The Application

1. Create a file named "**.env**" in your project directory

   > your-path-to-the-project/library-automation/.env

2. Copy and paste the text below and edit those values accordingly.

```
DB_USER=<your-sqlserver-username>
DB_PASSWORD=<your-sqlserver-password>
```

3. Apply these commands to create the tables in the database automatically,

```
  dotnet ef migrations add InitialCreate
  dotnet ef database update
```

4. Enjoy!
