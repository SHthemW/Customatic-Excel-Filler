﻿
def test(msg):
    try:
        return str("hello! " + msg)
    except Exception as e:
        return str("err" + str(e))


def default_file():
    return "hi, I am default."


    