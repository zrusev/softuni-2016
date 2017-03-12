<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>First Steps Into PHP</title>

</head>
<body>
    <form>
        N: <input type="text" name="num1" />
        M: <input type="text" name="num2" />
        <input type="submit" />
    </form>
	<ul>
        <?php
            if(isset($_GET['num1']) && isset($_GET['num2']))
            {
                for ($i = 1; $i <= intval($_GET['num1']); $i++)
                {
                    echo "<li>"."List ".$i;
                    echo "<ul>";
                    for ($a = 1; $a <= intval($_GET['num2']); $a++)
                    {
                        echo "<li>"."Element ".$i.".".$a."</li>";
                    }
                    echo "</ul>";
                    echo "</li>";
                }
            }
        ?>
	</ul>
</body>
</html>