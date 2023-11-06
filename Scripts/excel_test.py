
def get_next_row(prev_rows: list):
	try:
		return prev_rows[-1:][0]
	except Exception as e:
		return None