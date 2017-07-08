<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>First Steps Into PHP</title>

</head>
<body>
    <form>
        X: <input type="text" name="num1" />
		Y: <input type="text" name="num2" />
        Z: <input type="text" name="num3" />
		<input type="submit" />
    </form>
    <?php
        if(isset($_GET['num1']) && isset($_GET['num2']) && isset($_GET['num3'])) {
            $n1 = $_GET['num1'];
            $n2 = $_GET['num2'];
            $n3 = $_GET['num3'];
            $neg = 0;
            for ($i = 1; $i <= 3; $i++)
            {
                if(${'n'.$i} == 0)
                {
                    echo "Positive";
                    return;
                }
                elseif (${'n'.$i} < 0)
                {
                    $neg++;
                }
            }

            if($neg == 1 || $neg == 3)
            {
                echo "Negative";
            }
            else
            {
                echo "Positive";
            }
        }
    ?>
</body>
</html>