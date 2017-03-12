<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>First Steps Into PHP</title>
	<style>
		table * {
			border: 1px solid black;
			width: 50px;
			height: 50px;
		}
    </style>
</head>
<body>
<table>
    <tr>
        <td>
            Red
        </td>
        <td>
            Green
        </td>
        <td>
            Blue
        </td>
    </tr>
    <?php
    $clr = 51;
    for ($row = 0; $row < 5; $row++)
    {
        echo "<tr>";
        /*for ($col = 0; $col < 3; $col++)
        {*/
            echo "<td style='background-color: rgb($clr, 0, 0)'></td>";
            echo "<td style='background-color: rgb(0, $clr, 0)'></td>";
            echo "<td style='background-color: rgb(0, 0, $clr)'></td>";
        /*}*/
        echo "</tr>";
        $clr += 51;
    }
    ?>
</table>
</body>
</html>