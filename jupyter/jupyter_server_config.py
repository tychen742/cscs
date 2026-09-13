import os


c = get_config()

c.ServerApp.ip = "0.0.0.0"
c.ServerApp.port = 8888
c.ServerApp.open_browser = False
c.ServerApp.root_dir = "/workspace"
c.ServerApp.token = os.environ.get("JUPYTER_TOKEN", "")
c.ServerApp.password = ""
c.ServerApp.allow_credentials = False
c.ServerApp.allow_remote_access = True
c.ServerApp.allow_origin_pat = (
    r"^(https://(www\.)?thinkcscs\.org|"
    r"http://(localhost|127\.0\.0\.1)(:\d+)?)$"
)
